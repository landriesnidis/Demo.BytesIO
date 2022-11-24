using Demo.BytesIO.ChatProtocol;
using Newtonsoft.Json;
using STTech.BytesIO.Core;
using STTech.BytesIO.Serial;
using STTech.BytesIO.Tcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.Client
{
    public partial class ClientPanel : UserControl
    {
        private BytesClient client;

        private Dictionary<string, FileStream> dictFileStream = new Dictionary<string, FileStream>();


        private ClientPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public ClientPanel(BytesClient client) : this()
        {
            this.client = client;
            propertyGrid.SelectedObject = client;

            client.OnDataReceived += Client_OnDataReceived;
            client.OnConnectedSuccessfully += Client_OnConnectedSuccessfully;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnDataSent += Client_OnDataSent;
            client.OnExceptionOccurs += Client_OnExceptionOccurs;
        }

        private void Client_OnExceptionOccurs(object sender, STTech.BytesIO.Core.ExceptionOccursEventArgs e)
        {
            Print($"发生了一个异常：{e.Exception.Message}");
        }

        private void Client_OnDataSent(object sender, STTech.BytesIO.Core.DataSentEventArgs e)
        {
            // Print($"发送数据：{e.Data.EncodeToString("GBK")}");
        }

        private void Client_OnDisconnected(object sender, STTech.BytesIO.Core.DisconnectedEventArgs e)
        {
            Print($"已断开({e.ReasonCode})");
        }

        private void Client_OnConnectedSuccessfully(object sender, STTech.BytesIO.Core.ConnectedSuccessfullyEventArgs e)
        {
            Print("连接成功");
        }

        private void Client_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            // Print($"收到数据：{e.Data.EncodeToString("GBK")}");

            //var filePath = Path.Combine(tbSavePath.Text,"newfile.txt");
            //Print($"接收到文件，存放在：{filePath}");
            //File.WriteAllBytes(filePath, e.Data);

            ChatMessageResponse resp = new ChatMessageResponse(e.Data);

            switch (resp.Type)
            {
                case ChatMessageType.Text:
                    Print($"收到消息：{resp.Data.EncodeToString()}");
                    break;
                case ChatMessageType.FileInfo:
                case ChatMessageType.FileContent:
                case ChatMessageType.FileEnd:
                    var fileName = resp.Args.EncodeToString();
                    var filePath = Path.Combine(tbSavePath.Text, fileName);

                    if (resp.Type == ChatMessageType.FileInfo)
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        Directory.CreateDirectory(tbSavePath.Text);
                        Print($"正在接收文件：{fileName}");

                        dictFileStream[filePath] = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                    }
                    else if (resp.Type == ChatMessageType.FileContent)
                    {
                        FileStream fileStream = dictFileStream[filePath];
                        lock (fileStream)
                        {
                            fileStream.Write(resp.Data, 0, resp.Data.Length);
                        }
                    }
                    else if (resp.Type == ChatMessageType.FileEnd)
                    {
                        FileStream fileStream = dictFileStream[filePath];
                        fileStream.Close();
                        fileStream.Dispose();

                        Process.Start("Explorer.exe", $"/select,{filePath}");
                        Print($"完成接收文件：{filePath}");
                    }
                    break;
                case ChatMessageType.Shake:
                    this.ParentForm.Shake();
                    Print("收到一个窗口抖动");
                    break;

            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatMessageRequest message = new ChatMessageRequest()
            {
                Type = ChatMessageType.Text,
                Data = tbSend.Text.GetBytes(),
            };
            client.SendAsync(message.GetBytes());
        }

        private void Print(string msg)
        {
            tbRecv.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    Task.Run(() => SendFile(filePath));
                }
            }
        }

        private void SendFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileSize = new FileInfo(filePath).Length;

            ChatMessageRequest req1 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileInfo,
                Args = fileName.GetBytes(),
            };
            client.SendAsync(req1.GetBytes());
            Print($"准备发送文件: {fileName}, 总大小: {fileSize}字节");

            int sentCount = 0;
            using (FileStream fs = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[10000];
                int len = 0;
                while ((len = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Thread.Sleep(50);

                    ChatMessageRequest req2 = new ChatMessageRequest()
                    {
                        Type = ChatMessageType.FileContent,
                        Data = len == buffer.Length ? buffer : buffer.Take(len).ToArray(),
                        Args = fileName.GetBytes(),
                    };
                    client.SendAsync(req2.GetBytes());

                    sentCount += len;
                    Print($"发送文件:{fileName} ({sentCount * 100.0 / fileSize}%)");
                }
            }

            Thread.Sleep(50);

            ChatMessageRequest req3 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileEnd,
                Args = fileName.GetBytes(),
            };
            client.SendAsync(req3.GetBytes());

            Print($"文件发送完毕：{fileName}");
        }

        private void btnSendShake_Click(object sender, EventArgs e)
        {
            ChatMessageRequest message = new ChatMessageRequest()
            {
                Type = ChatMessageType.Shake,
            };
            client.SendAsync(message.GetBytes());
            Print("发送一个窗口抖动");
        }
    }
}

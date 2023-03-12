using Demo.BytesIO.ChatProtocol;
using Demo.BytesIO.ChatSdk.Entitiy;
using STTech.BytesIO.Core;
using STTech.BytesIO.Core.Component;
using STTech.BytesIO.Tcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.BytesIO.ChatSdk
{
    public class ChatClient : VirtualClient,IUnpackerSupport<ChatMessageResponse>
    {
        public Unpacker<ChatMessageResponse> Unpacker { get; }

        private Dictionary<string, FileStream> dictFileStream = new Dictionary<string, FileStream>();

        public string FileSavePath { get; set; } = "./Recv";

        /// <summary>
        /// 文件发送中的事件
        /// </summary>
        public event EventHandler<FileSendingEventArgs> FileSending;

        /// <summary>
        /// 文件已发送的事件
        /// </summary>
        public event EventHandler<FileSentEventArgs> FileSent;

        /// <summary>
        /// 接收到文本消息的事件
        /// </summary>
        public event EventHandler<TextReceivedEventArgs> TextReceived;

        /// <summary>
        /// 接收到抖动消息的事件
        /// </summary>
        public event EventHandler<ShakeReceivedEventArgs> ShakeReceived;

        /// <summary>
        /// 开始接收文件的事件
        /// </summary>
        public event EventHandler<FileAcceptEventArgs> FileAccept;

        /// <summary>
        /// 文件接收完成的事件
        /// </summary>
        public event EventHandler<FileReceivedEventArgs> FileReceived;

        public ChatClient()
        {
            Unpacker = new Unpacker<ChatMessageResponse>(this,bytes => {
                var len = bytes.Count();
                if (len < 5)
                {
                    return 0;
                }
                var arr = bytes.Take(5).ToArray();
                var dataLen = BitConverter.ToUInt16(arr,1);
                var argsLen = BitConverter.ToUInt16(arr,3);
                return 5 + dataLen + argsLen;
            });
            this.BindUnpacker(Unpacker);
            Unpacker.OnDataParsed += Unpacker_OnDataParsed;
        }

        private void Unpacker_OnDataParsed(object sender, DataParsedEventArgs<ChatMessageResponse> e)
        {
            var resp = e.Data;
            switch (resp.Type)
            {
                case ChatMessageType.Text:
                    TextReceived?.Invoke(this,new TextReceivedEventArgs() { Text = resp.Data.EncodeToString() });
                    break;
                case ChatMessageType.FileInfo:
                case ChatMessageType.FileContent:
                case ChatMessageType.FileEnd:
                    var fileName = resp.Args.EncodeToString();
                    var filePath = Path.Combine(FileSavePath, fileName);

                    if (resp.Type == ChatMessageType.FileInfo)
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        Directory.CreateDirectory(FileSavePath);

                        FileAccept?.Invoke(this,new FileAcceptEventArgs() {
                            FilePath = filePath
                        });

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
                        dictFileStream.Remove(filePath);

                        FileReceived?.Invoke(this, new FileReceivedEventArgs()
                        {
                            FilePath = filePath
                        });
                    }
                    break;
                case ChatMessageType.Shake:
                    ShakeReceived?.Invoke(this,new ShakeReceivedEventArgs());
                    break;
            }
        }

        public void SendText(string text)
        {
            this.Send(new ChatMessageRequest()
            {
                Type = ChatMessageType.Text,
                Data = text.GetBytes(),
            });
        }

        public void SendShake()
        {
            this.Send(new ChatMessageRequest()
            {
                Type = ChatMessageType.Shake,
            });
        }

        public void SendFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileSize = new FileInfo(filePath).Length;

            ChatMessageRequest req1 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileInfo,
                Args = fileName.GetBytes(),
            };
            this.SendAsync(req1);
            // Print($"准备发送文件: {fileName}, 总大小: {fileSize}字节");

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
                    this.Send(req2);
                    sentCount += len;

                    // Print($"发送文件:{fileName} ({sentCount * 100.0 / fileSize}%)");
                    FileSending?.Invoke(this,new FileSendingEventArgs() { 
                        FileName = fileName,
                        SentLen = sentCount,
                        FileSize = fileSize,
                    });
                }
            }

            Thread.Sleep(50);

            ChatMessageRequest req3 = new ChatMessageRequest()
            {
                Type = ChatMessageType.FileEnd,
                Args = fileName.GetBytes(),
            };
            this.SendAsync(req3);

            // Print($"文件发送完毕：{fileName}");
            FileSent?.Invoke(this,new FileSentEventArgs() {
                FileName = fileName,
            });
        }
    }
}

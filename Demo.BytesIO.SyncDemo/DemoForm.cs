using STTech.BytesIO.Core;
using STTech.BytesIO.Serial;
using STTech.BytesIO.Tcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.SyncDemo
{
    public partial class DemoForm : Form
    {
        private BytesClient client = new TcpClient() { Port = 60000 };

        public DemoForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            client.OnConnectedSuccessfully += (s, e) => Print("连接成功");
            client.OnConnectionFailed += (s, e) => Print("连接失败");
            client.OnDisconnected += (s, e) => Print("断开连接");
            client.OnDataReceived += (s, e) => Print($"收到数据：{e.Data.ToHexString()}");
            client.OnDataSent += (s, e) => Print($"发送数据：{e.Data.ToHexString()}");
            client.Connect();
        }

        private void Print(string msg)
        {
            tbRecv.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void tsmiTest_Click(object sender, EventArgs e)
        {
            var reply = client.Send(new byte[] { 0xAA, 0x01, 0xFF, 0xFF, 0xFF }, 5000, (sd, rd) => {
                return rd[0] == 0xBB && sd[1] == rd[1];
            });

            if(reply.Status == STTech.BytesIO.Core.Entity.ReplyStatus.Completed)
            {
                Print($"收到回复，内容是：{reply.Data.ToHexString()}");
            }
            else
            {
                Print($"未收到回复，原因是：{reply.Status}");
            }
        }
    }
}

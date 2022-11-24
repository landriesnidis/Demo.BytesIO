using STTech.BytesIO.Core;
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

namespace Demo.BytesIO.Server
{
    public partial class ServerForm : Form
    {
        private TcpServer server;
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            server = new TcpServer();
            server.Port = int.Parse(tbPort.Text);

            server.Started += Server_Started;
            server.Closed += Server_Closed;
            server.ClientConnected += Server_ClientConnected;
            server.ClientDisconnected += Server_ClientDisconnected;

            server.ClientConnectionAcceptedHandle = (s, e) =>
            {
                if (server.Clients.Count() < 3)
                {
                    return true;
                }
                else
                {
                    Print($"服务器已满，关闭客户端[{e.ClientSocket.RemoteEndPoint}]的连接.");
                    return false;
                }
            };
        }

        private void Server_ClientDisconnected(object sender, STTech.BytesIO.Tcp.Entity.ClientDisconnectedEventArgs e)
        {
            Print($"客户端[{e.Client.Host}:{e.Client.Port}]断开连接");
        }

        private void Server_ClientConnected(object sender, STTech.BytesIO.Tcp.Entity.ClientConnectedEventArgs e)
        {
            Print($"客户端[{e.Client.Host}:{e.Client.Port}]连接成功");
            e.Client.OnDataReceived += Client_OnDataReceived;
        }

        private void Client_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            TcpClient tcpClient = (TcpClient)sender;
            // Print($"来自客户端[{tcpClient.RemoteEndPoint}]的消息: {e.Data.ToHexString()}");

            foreach (TcpClient client in server.Clients)
            {
                if (client != tcpClient)
                {
                    client.SendAsync(e.Data);
                }
            }
        }

        private void Server_Closed(object sender, EventArgs e)
        {
            Print("停止监听");
        }

        private void Server_Started(object sender, EventArgs e)
        {
            Print($"开始监听({server.Port})");
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            server.Port = int.Parse(tbPort.Text);
            server.StartAsync();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            server.CloseAsync();
        }

        private void Print(string msg)
        {
            tbLog.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void cbClients_DropDown(object sender, EventArgs e)
        {
            cbClients.Items.Clear();
            cbClients.Items.AddRange(server.Clients.Select(c => c.RemoteEndPoint.ToString()).ToArray());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var client = server.Clients.FirstOrDefault(c => c.RemoteEndPoint.ToString() == cbClients.Text);
            client?.Send(tbSend.Text.GetBytes());
        }
    }
}

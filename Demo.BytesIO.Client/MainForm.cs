﻿using STTech.BytesIO.Core;
using STTech.BytesIO.Core;
using STTech.BytesIO.Serial;
using STTech.BytesIO.Tcp;
using STTech.BytesIO.Udp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiCreateTcpClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("TCP客户端", new ClientPanel(new ChatSdk.ChatClient() { InnerClient = new TcpClient() { Port = 60000 } }));
        }

        private void tsmiCreateSerialClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("串口客户端", new ClientPanel(new ChatSdk.ChatClient() { InnerClient = new SerialClient() { ReceiveBufferSize = 65536, SendBufferSize = 65536 } }));
        }

        private void tsmiCreateUdpClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("UDP客户端", new ClientPanel(new ChatSdk.ChatClient() { InnerClient = new UdpClient() { Port = 60000, LocalPort = 60001 } }));
        }
    }
}

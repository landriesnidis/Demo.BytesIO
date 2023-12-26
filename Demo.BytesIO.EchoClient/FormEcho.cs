using STTech.BytesIO.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.EchoClient
{
    public partial class EchoForm : Form
    {
        private SerialClient serialClient;

        public EchoForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            serialClient = new SerialClient();
            serialClient.OnConnectedSuccessfully += SerialClient_OnConnectedSuccessfully;
            serialClient.OnConnectionFailed += SerialClient_OnConnectionFailed;
            serialClient.OnDisconnected += SerialClient_OnDisconnected;
            serialClient.OnDataReceived += SerialClient_OnDataReceived;
        }

        private void SerialClient_OnDisconnected(object sender, STTech.BytesIO.Core.DisconnectedEventArgs e)
        {
            Text = "SerialClient_OnDisconnected";
        }

        private void SerialClient_OnConnectionFailed(object sender, STTech.BytesIO.Core.ConnectionFailedEventArgs e)
        {
            Text = "SerialClient_OnConnectionFailed";
        }

        private void SerialClient_OnConnectedSuccessfully(object sender, STTech.BytesIO.Core.ConnectedSuccessfullyEventArgs e)
        {
            Text = "SerialClient_OnConnectedSuccessfully";
        }

        private void SerialClient_OnDataReceived(object sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            Task.Delay(tbarDelay.Value * 1000).Wait();
            lock (serialClient)
            {
                foreach (var b in e.Data.Slice(2))
                {
                    serialClient.Send(b.ToArray());

                    if (cbSliceData.Checked)
                    {
                        Task.Delay(1).Wait();
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            serialClient.Disconnect();
            serialClient.PortName = cbPortName.Text;
            serialClient.BaudRate = (int)nudBaudRate.Value * 1000;
            serialClient.Connect();
        }

        private void cbPortName_DropDown(object sender, EventArgs e)
        {
            cbPortName.Items.Clear();
            cbPortName.Items.AddRange(serialClient.GetPortNames());
        }

        private void tbarDelay_ValueChanged(object sender, EventArgs e)
        {
            labDelay.Text = $"{tbarDelay.Value * 1000} ms";
        }
    }
}

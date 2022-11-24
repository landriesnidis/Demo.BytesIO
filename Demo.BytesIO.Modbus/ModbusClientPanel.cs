using ApeFree.ApeDialogs;
using ApeFree.ApeDialogs.Settings;
using ApeFree.ApeForms.Forms.Dialogs;
using STTech.BytesIO.Core;
using STTech.BytesIO.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.Modbus
{
    public partial class ModbusClientPanel : UserControl
    {
        private readonly ModbusClient client;
        private readonly ApeFormsDialogProvider dialogProvider;

        private ModbusClientPanel()
        {
            InitializeComponent();

            dialogProvider = DialogFactory.Factory.GetApeFormsDialogProvider();
        }

        public ModbusClientPanel(ModbusClient client) : this()
        {
            this.client = client;
            pgConnectionInfo.SelectedObject = client;

            client.OnDataReceived += Client_OnDataReceived; ;
            client.OnConnectedSuccessfully += Client_OnConnectedSuccessfully;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnDataSent += Client_OnDataSent;
            client.OnExceptionOccurs += Client_OnExceptionOccurs;

            btnNewRequest.DropDownItems.Add("读线圈寄存器", null, (s, e) => pgRequest.SelectedObject = new ReadCoilRegisterRequest());
            btnNewRequest.DropDownItems.Add("读离散输入寄存器", null, (s, e) => pgRequest.SelectedObject = new ReadDiscreteInputRegisterRequest());
            btnNewRequest.DropDownItems.Add("读保持寄存器", null, (s, e) => pgRequest.SelectedObject = new ReadHoldRegisterRequest());
            btnNewRequest.DropDownItems.Add("读输入寄存器", null, (s, e) => pgRequest.SelectedObject = new ReadInputRegisterRequest());
            btnNewRequest.DropDownItems.Add("写单个线圈寄存器", null, (s, e) => pgRequest.SelectedObject = new WriteSingleCoilRegisterRequest());
            btnNewRequest.DropDownItems.Add("写单个保持寄存器", null, (s, e) => pgRequest.SelectedObject = new WriteSingleHoldRegisterRequest());
            btnNewRequest.DropDownItems.Add("写多个线圈寄存器", null, (s, e) => pgRequest.SelectedObject = new WriteMultipleCoilRegistersRequest());
            btnNewRequest.DropDownItems.Add("写多个保持寄存器", null, (s, e) => pgRequest.SelectedObject = new WriteMultipleHoldRegistersRequest());
        }

        private void Client_OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            Print($"收到数据：{e.Data.ToHexString()}");
        }

        private void Client_OnExceptionOccurs(object sender, STTech.BytesIO.Core.ExceptionOccursEventArgs e)
        {
            Print($"发生异常：{e.Exception.Message}");
        }

        private void Client_OnDataSent(object sender, STTech.BytesIO.Core.DataSentEventArgs e)
        {
            Print($"发送数据：{e.Data.ToHexString()}");
        }

        private void Client_OnDisconnected(object sender, STTech.BytesIO.Core.DisconnectedEventArgs e)
        {
            Print($"已断开({e.ReasonCode})");
            pgConnectionInfo.Enabled = true;
        }

        private void Client_OnConnectedSuccessfully(object sender, STTech.BytesIO.Core.ConnectedSuccessfullyEventArgs e)
        {
            Print("连接成功");
            pgConnectionInfo.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void pgRequest_SelectedObjectsChanged(object sender, EventArgs e)
        {
            var request = pgRequest.SelectedObject;
            panelRequest.Enabled = request != null;
            btnEditHex.Visible = request is WriteSingleHoldRegisterRequest || request is WriteMultipleHoldRegistersRequest;
        }

        private void Print(string msg)
        {
            tbLog.AppendText($"[{DateTime.Now}] {msg}\r\n");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            //var reply = client.ReadCoilRegister(1, 1, 1, 3000);
            //if (reply.Status == ReplyStatus.Completed)
            //{
            //    var resp = reply.GetResponse();
            //}

            var request = pgRequest.SelectedObject as ModbusRequest;
            client.Send(request.GetBytes());
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void btnEditHex_Click(object sender, EventArgs e)
        {
            var dialog = dialogProvider.CreateInputDialog(new InputDialogSettings()
            {
                Title = "编辑数据段",
                Content = "请输入十六进制格式的数据",
                PrecheckResult = hex =>
                {
                    try
                    {
                        hex.HexStringToBytes();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            });
            dialog.Show();
            if (!dialog.Result.IsCancel)
            {
                var bytes = dialog.Result.Data.HexStringToBytes();
                var request = pgRequest.SelectedObject;
                if (request is WriteSingleHoldRegisterRequest req1)
                {
                    req1.Data = bytes;
                }
                else if (request is WriteMultipleHoldRegistersRequest req2)
                {
                    req2.Data = bytes;
                }
            }
        }

    }
}

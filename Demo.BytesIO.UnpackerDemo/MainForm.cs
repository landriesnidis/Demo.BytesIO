using Newtonsoft.Json;
using STTech.BytesIO.Core.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Demo.BytesIO.UnpackerDemo.SimpleData;

namespace Demo.BytesIO.UnpackerDemo
{
    public partial class MainForm : Form
    {
        private SimpleDataUnpacker unpacker = new SimpleDataUnpacker();

        public MainForm()
        {
            InitializeComponent();
            unpacker.OnDataParsed += Unpacker_OnDataParsed;
        }

        private void Unpacker_OnDataParsed(object sender, DataParsedEventArgs e)
        {
            try
            {
                SimpleData data = new SimpleData(e.Data);

                // 显示数据
                propertyGrid.SelectedObject = data;
                Print(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // 模拟数据
            Random random = new Random();
            FunctionCode code = (FunctionCode)random.Next(0, 3);
            short value1 = (short)random.Next(0, 359);
            short value2 = (short)random.Next(0, 359);
            SimpleData newData = new SimpleData(code, value1, value2);

            // 读取模拟数据的字节数组并显示在输入框
            var bytes = newData.GetBytes();
            tbInput.Text = bytes.ToHexString();

            // 将模拟数据传入解包器中
            unpacker.Input(bytes);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                // 将输入框内的16进制字符串转为字节数组再传入解包器
                var bytes = tbInput.Text.HexStringToBytes();
                unpacker.Input(bytes);
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }

        private void Print(string msg)
        {
            tbResult.AppendText($"{msg}\r\n");
        }
    }
}

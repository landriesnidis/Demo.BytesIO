using Newtonsoft.Json;
using STTech.BytesIO.Core.Component;
using STTech.BytesIO.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Demo.BytesIO.DataUnpacker.SimpleData;

namespace Demo.BytesIO.DataUnpacker
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

    /// <summary>
    /// 数据协议
    /// </summary>
    public class SimpleData : Response, IRequest
    {
        /// <summary>
        /// 协议起始标记
        /// </summary>
        public static readonly byte[] StartMark = new byte[] { 0xDD, 0xEE };

        /// <summary>
        /// 功能码
        /// </summary>
        public FunctionCode Code { get; }

        /// <summary>
        /// 方位角度
        /// </summary>
        public short Heading { get; }

        /// <summary>
        /// 俯仰角度
        /// </summary>
        public short Tilt { get; }

        public SimpleData(IEnumerable<byte> bytes) : base(bytes)
        {
            var data = bytes.ToArray();
            if (bytes.Count() != 8)
            {
                throw new ArgumentException("长度应为8位");
            }
            if (!bytes.StartWith(StartMark))
            {
                throw new ArgumentException("协议头错误");
            }
            if (CheckSum(bytes.Skip(2).Take(5)) != bytes.Last())
            {
                throw new ArgumentException("校验失败");
            }
            Code = (FunctionCode)data[2];
            Heading = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 3));
            Tilt = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 5));
        }

        public SimpleData(FunctionCode code, short heading, short tilt) : base(null)
        {
            Code = code;
            Heading = heading;
            Tilt = tilt;
        }

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(StartMark);
            bytes.Add((byte)Code);
            bytes.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Heading)));
            bytes.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Tilt)));
            byte checkSum = CheckSum(bytes.Skip(2));
            bytes.Add(checkSum);
            return bytes.ToArray();
        }

        private byte CheckSum(IEnumerable<byte> bytes)
        {
            byte checksum = 0x00;
            foreach (byte bt in bytes)
            {
                checksum ^= bt;
            }
            return checksum;
        }

        /// <summary>
        /// 功能码
        /// </summary>
        public enum FunctionCode : byte
        {
            /// <summary>
            /// 停止
            /// </summary>
            Stop = 0,
            /// <summary>
            /// 定点
            /// </summary>
            FixedPoint = 1,
            /// <summary>
            /// 扇扫
            /// </summary>
            Scan = 2,
        }
    }

    /// <summary>
    /// 固定长度的协议解包器
    /// 数据包长度固定，实现非常简单；
    /// 重写CalculatePacketLength方法时返回固定长度值即可
    /// </summary>
    public class SimpleDataUnpacker : Unpacker
    {
        public SimpleDataUnpacker()
        {
            StartMark = SimpleData.StartMark;
        }

        protected override int CalculatePacketLength(IEnumerable<byte> bytes) => 8;
    }

    /// <summary>
    /// 非固定长度的协议解包器
    /// 数据包长度存放于数据包内指定位
    /// </summary>
    public class SimpleData2Unpacker : Unpacker
    {
        public SimpleData2Unpacker()
        {
            StartMark = new byte[] { 0xAA, 0xBB };
        }

        protected override int CalculatePacketLength(IEnumerable<byte> bytes)
        {
            if (bytes.Count() < 3)
            {
                return 0;
            }
            else
            {
                return bytes.ElementAt(2) + 3;
            }
        }
    }

    /// <summary>
    /// 非固定长度的协议解包器
    /// 通过匹配特定的协议起始标记和结束标记来截取数据包
    /// </summary>
    public class SimpleData3Unpacker : Unpacker
    {
        private byte[] EndMark { get; } = new byte[] { 0xEE, 0xFF };

        public SimpleData3Unpacker()
        {
            StartMark = new byte[] { 0xAA, 0xBB };
        }

        protected override int CalculatePacketLength(IEnumerable<byte> bytes)
        {
            var index = bytes.IndexOf(EndMark);
            if (index < 0)
            {
                return 0;
            }
            else
            {
                return index + EndMark.Length;
            }
        }
    }
}

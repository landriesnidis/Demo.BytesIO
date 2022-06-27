using STTech.BytesIO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Demo.BytesIO.UnpackerDemo
{
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
}

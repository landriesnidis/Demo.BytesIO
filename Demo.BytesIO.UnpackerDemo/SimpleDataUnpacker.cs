using STTech.BytesIO.Core.Component;
using System.Collections.Generic;

namespace Demo.BytesIO.UnpackerDemo
{
    /// <summary>
    /// 自定义解包器
    /// 协议固定长度为8，所以协议实现非常简单；
    /// 重写CalculatePacketLength方法时固定返回“8”即可
    /// </summary>
    public class SimpleDataUnpacker : Unpacker
    {
        public SimpleDataUnpacker()
        {
            StartMark = SimpleData.StartMark;
        }

        protected override int CalculatePacketLength(IEnumerable<byte> bytes) => 8;
    }
}

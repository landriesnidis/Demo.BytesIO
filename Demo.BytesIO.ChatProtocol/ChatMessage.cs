using STTech.BytesIO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.BytesIO.ChatProtocol
{
    public class ChatMessageRequest:IRequest
    {
        public ChatMessageType Type { get; set; }
        public ushort DataLen => (ushort)Data?.Length;
        public ushort ArgsLen => (ushort)Args?.Length;
        public byte[] Data { get; set; } = new byte[0];
        public byte[] Args { get; set; } = new byte[0];

        public byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.Add((byte)Type);
            bytes.AddRange(BitConverter.GetBytes(DataLen));
            bytes.AddRange(BitConverter.GetBytes(ArgsLen));
            bytes.AddRange(Data);
            bytes.AddRange(Args);
            return bytes.ToArray();
        }
    }

    public class ChatMessageResponse : Response
    {
        public ChatMessageType Type { get; }
        public ushort DataLen { get; }
        public ushort ArgsLen { get; }
        public byte[] Data { get; }
        public byte[] Args { get; }

        public ChatMessageResponse(IEnumerable<byte> bytes) : base(bytes)
        {
            var array = bytes.ToArray();

            Type = (ChatMessageType)array[0];
            DataLen = BitConverter.ToUInt16(array, 1);
            ArgsLen = BitConverter.ToUInt16(array, 3);
            Data = bytes.Skip(5).Take(DataLen).ToArray();
            Args = bytes.Skip(5 + DataLen).Take(ArgsLen).ToArray();
        }
    }

    public enum ChatMessageType
    {
        Text,
        FileInfo,
        FileContent,
        FileEnd,
        Shake,
    }
}

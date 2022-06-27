using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BytesIO.ChatSdk.Entitiy
{
    /// <summary>
    /// 文件发送中的事件参数
    /// </summary>
    public class FileSendingEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public int SentLen { get; set; }
        public long FileSize { get; set; }
    }

    /// <summary>
    /// 文件已发送的事件参数
    /// </summary>
    public class FileSentEventArgs : EventArgs
    {
        public string FileName { get; internal set; }
    }

    /// <summary>
    /// 接收到文本消息的事件参数
    /// </summary>
    public class TextReceivedEventArgs : EventArgs
    {
        public string Text { get; internal set; }
    }

    /// <summary>
    /// 接收到抖动消息的事件参数
    /// </summary>
    public class ShakeReceivedEventArgs : EventArgs
    {
    }

    /// <summary>
    /// 开始接收文件的事件参数
    /// </summary>
    public class FileAcceptEventArgs : EventArgs
    {
        public string FilePath { get; internal set; }
    }

    /// <summary>
    /// 文件接收完成的事件参数
    /// </summary>
    public class FileReceivedEventArgs : EventArgs
    {
        public string FilePath { get; internal set; }
    }



}

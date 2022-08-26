using STTech.BytesIO.Tcp;
using System;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Demo.BytesIO.Tcp.Tls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient()
            {
                Host = "127.0.0.1",
                Port = 8080,
                UseSsl = true, // 启用加密功能
                SslProtocol = SslProtocols.Tls12, // 选择协议版本
                Certificate = new X509Certificate2(@"C:/xxxx/xxxx/证书.pfx", "证书密码（无密码可不填）"),
            };
            client.OnConnectedSuccessfully += Client_OnConnectedSuccessfully;
            client.OnConnectionFailed += Client_OnConnectionFailed;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnTlsVerifySuccessfully += Client_OnTlsVerifySuccessfully;
        }

        private static void Client_OnDisconnected(object sender, STTech.BytesIO.Core.Entity.DisconnectedEventArgs e)
        {
            Console.WriteLine("连接断开");
        }

        private static void Client_OnConnectionFailed(object sender, STTech.BytesIO.Core.Entity.ConnectionFailedEventArgs e)
        {
            Console.WriteLine("连接失败");
        }

        private static void Client_OnConnectedSuccessfully(object sender, STTech.BytesIO.Core.Entity.ConnectedSuccessfullyEventArgs e)
        {
            Console.WriteLine("连接成功");
        }

        private static void Client_OnTlsVerifySuccessfully(object sender, STTech.BytesIO.Tcp.Entity.TlsVerifySuccessfullyEventArgs e)
        {
            Console.WriteLine("TLS验证成功");
        }
    }
}

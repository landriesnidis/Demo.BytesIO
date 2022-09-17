using STTech.BytesIO.Tcp;

namespace Demo.BytesIO.TcpSdkServer.Sdk
{
    public class TestSdkServer : TcpServer<TestSdkClient>
    {
        public TestSdkServer()
        {
            EncapsulateSocket = socket => new TestSdkClient(socket);
        }
    }

    public class TestSdkClient : TcpClient
    {
        public TestSdkClient(System.Net.Sockets.Socket socket) : base(socket) { }

        // 服务内客户端的方法、解包器、Request、Response...与正常客户端基本一致，
        // 唯一需要注意的是：
        // 正常客户端的发送的是XXXRequest，接收到的是XXXResponse;
        // 服务内的客户端接收到的相反（即接收到的是请求包，回复的是响应包）；

        // 提示：
        // 如果服务端和客户端想公用一套请求/响应实体类，可以这样写：
            /*
            public class XXXRequest: Response,IRequest
            {
                ...
            }

            public class XXXResponse: Response,IRequest
            {
                ...
            }
             */
        // 请求和响应的实体类都可做请求包和响应包来用，
        // 但服务内客户端的解包器需要解析的类型应改为XXXRequest（即解析客户端发来的请求包）

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkServer
{
    class Server
    {
        public const int buffsize = 1024;
        public Socket socket;
        public bool isUse = false;
        public byte[] readbuff = new byte[buffsize];
        public int buffCount = 0;
        public Server()
        {
            readbuff = new byte[buffsize];

        }
        public void Init(Socket socket)
        {
            this.socket = socket;
            isUse = true;
            buffCount = 0;

        }
        public int buffRemain()
        {
            return buffsize - buffCount;
        }
        public string GetAdress()
        {
            if (!isUse)
            {
                return "无法获取地址";

            }
            return socket.RemoteEndPoint.ToString();

        }
        public void Close()
        {
            if (!isUse)
                return;
            Console.WriteLine(GetAdress() + "与服务器断开连接");
            socket.Close();
            isUse = false;

        }
    }
}
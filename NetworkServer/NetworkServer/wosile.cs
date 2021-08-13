using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkServer
{
    class wosile
    {

        public Socket listedfd;//jianting
        public Server[] conns;
        public int maxconn = 3;
        public int NewIndex()
        {
            if (conns == null)
            {
                return -1;
            }
            for (int i = 0; i < conns.Length; i++)
            {
                if (conns[i] == null)
                {
                    conns[i] = new Server();
                    return i;
                }
                else if (conns[i].isUse == false)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Start(string host, int port)
        {
            conns = new Server[maxconn];
            for (int i = 0; i < maxconn; i++)
            {
                conns[i] = new Server();
            }
            listedfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAdr = IPAddress.Parse(host);
            IPEndPoint ipEp = new IPEndPoint(ipAdr, port);

            listedfd.Bind(ipEp);
            listedfd.Listen(maxconn);
            listedfd.BeginAccept(AcceptCb, null);
            Console.WriteLine("服务器启动成功");

        }
        private void AcceptCb(IAsyncResult ar)
        {
            try
            {
                Socket socket = listedfd.EndAccept(ar);
                int index = NewIndex();
                if (index < 0)
                {
                    socket.Close();
                    Console.WriteLine("警告：连接已满");

                }
                else
                {
                    Server conn = conns[index];
                    conn.Init(socket);
                    string adr = conn.GetAdress();
                    Console.WriteLine("有客户连接" + adr + "id号为" + index);
                    conn.socket.BeginReceive(conn.readbuff, conn.buffCount, conn.buffRemain(), SocketFlags.None, ReceiveCb, conn);
                    listedfd.BeginAccept(AcceptCb, null);
                    for (int i = 0; i < conns.Length; i++)
                    {
                        if (conns[i] == null)
                            continue;
                        if (!conns[i].isUse)
                            continue;
                        Console.WriteLine("服务器将消息转发给" + conns[i].GetAdress());
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(adr);
                        conns[i].socket.Send(bytes);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("回调失败" + e.Message);

            }
        }
        private void ReceiveCb(IAsyncResult ar)
        {
            Server conn = (Server)ar.AsyncState;
            try
            {
                int count = conn.socket.EndReceive(ar);
                if (count <= 0)
                {
                    Console.WriteLine(conn.GetAdress() + "与服务器断开连接");
                    conn.Close();
                    return;

                }
                string str = System.Text.Encoding.UTF8.GetString(conn.readbuff, 0, count);
                Console.WriteLine("收到发送过来的数据" + str);
                //str = conn.GetAdress() + ":" + str;
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
                for (int i = 0; i < conns.Length; i++)
                {
                    if (conns[i] == null)
                        continue;
                    if (!conns[i].isUse)
                        continue;
                    Console.WriteLine("服务器将消息转发给" + conns[i].GetAdress());
                    conns[i].socket.Send(bytes);



                }
                conn.socket.BeginReceive(conn.readbuff, conn.buffCount, conn.buffRemain(), SocketFlags.None, ReceiveCb, conn);

            }
            catch (Exception e)
            {
                Console.WriteLine("收到" + conn.GetAdress() + "断开连接" + e.Message);
            }
        }
    }
}

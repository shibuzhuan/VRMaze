using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();   //获取本机名
            string localaddr = "";
            //IPHostEntry localhost = Dns.GetHostByName(hostName);
            //IPAddress localaddr = localhost.AddressList[0];


            IPHostEntry localhost = Dns.GetHostByName(hostName);
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress item in IpEntry.AddressList)
            {
                //AddressFamily.InterNetwork  ipv4
                //AddressFamily.InterNetworkV6 ipv6
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    localaddr = item.ToString();
                }

            }
            Console.WriteLine("本机ip地址" + localaddr);

            //Console.WriteLine("hello");
            wosile server = new wosile();
            server.Start(localaddr.ToString(), 1989);

            //Console.WriteLine("本机ip地址" +ip);
            while (true)
            {
                string str = Console.ReadLine();
                switch (str)
                {
                    case "quit":
                        return;

                }

            }
        }
        //static void Main(string[] args)
        //{
        //    /*创建一个socket对象*/
        //    //寻址方式 套接字类型 协议方式
        //    Socket tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    /*绑定监听消息IP和端口号*/
        //    string hostName = Dns.GetHostName();   //获取本机名
        //    string localaddr = "";
        //    //IPHostEntry localhost = Dns.GetHostByName(hostName);
        //    //IPAddress localaddr = localhost.AddressList[0];


        //    IPHostEntry localhost = Dns.GetHostByName(hostName);
        //    IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
        //    foreach (IPAddress item in IpEntry.AddressList)
        //    {
        //        //AddressFamily.InterNetwork  ipv4
        //        //AddressFamily.InterNetworkV6 ipv6
        //        if (item.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            localaddr = item.ToString();
        //        }

        //    }
        //    //localaddr = "192.168.2.217";
        //    IPAddress ip = IPAddress.Parse(localaddr.ToString());
        //    EndPoint endPoint = new IPEndPoint(ip, 1989);
        //    tcpSocket.Bind(endPoint);//向操作系统申请一个ip和端口号
        //    Console.WriteLine("服务器端启动完成");
        //    Console.WriteLine("本机ip地址" + localaddr);

        //    /*开始监听客户端的连接请求*/
        //    tcpSocket.Listen(100);//最多可以接收100个客户端请求
        //    Socket socket = tcpSocket.Accept();//暂停当前线程，直到接收到客户端发来的连接请求；当接收到客户端的连接请求后，在本地服务器创建一个socket与客户端连接，并返回出来
        //    Console.WriteLine("有个客户端连接进来");

        //    /*向客户端发送消息*/
        //    string messge;
        //    messge = "你好,我有什么可以帮助到你吗";
        //    var date = ASCIIEncoding.UTF8.GetBytes(messge);
        //    socket.Send(date);


        //    /*从客户端接收消息*/
        //    byte[] bt = new byte[1024];//设置一个消息接收缓冲区
        //    int message = socket.Receive(bt);//该状态处于一个暂停状态，知道接收到消息，并返回字节数
        //    Console.WriteLine("接收到从客户端发来的消息:" + ASCIIEncoding.UTF8.GetString(bt));
        //    Console.ReadLine();
        //}

    }
}

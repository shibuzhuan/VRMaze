using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;
using System;

public class Client : MonoBehaviour
{
    //private Socket tcpSocket;
    
    //public InputField hostinput;

    //显示客户端接收的消息
    //public Text connecttext;
    public string serverstr;//服务器发送回的数据

    //public Text txtstr;//ui显示发送回来的数据

    //public InputField textinput;
    static Socket socket;

    const int buffsize = 1024;
    public byte[] readbuff = new byte[buffsize];
    private void Start()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        string host = "192.168.43.84";
        int port = 1989;
        try
        {
            socket.Connect(host, port);
            print("pc客户端地址连接成功" + socket.LocalEndPoint);
        }
        catch
        {
            print("pc客户端连接失败");
        }

        //bunext.active = true;
       
        //connecttext.text = "pc客户端连接成功" + socket.LocalEndPoint.ToString();
        //创建socket
        //连接服务器
        //Socket tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ///*绑定监听消息IP和端口号*/

        //IPAddress ip = IPAddress.Parse("192.168.43.84");
        //tcpSocket.Connect(ip, 1989);
        //Debug.Log("连接服务器");
        //////接收消息
        //byte[] bt = new byte[1024];
        //int messgeLength = tcpSocket.Receive(bt);
        //Debug.Log(ASCIIEncoding.UTF8.GetString(bt));
        ////发送消息
        //tcpSocket.Send(ASCIIEncoding.UTF8.GetBytes("我是电脑我有个问题"));
    }
    public void Send(string str)
    {

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
        
        try
        {
            socket.Send(bytes);
        }
        catch
        {

        }
    }
}

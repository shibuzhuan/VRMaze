using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;
using System;
using System.Net;

public class Client : MonoBehaviour
{
    //public GameObject bunext;
    //public InputField hostinput;

    //显示客户端接收的消息
    //public Text connecttext;
    private string serverstr;
    public string serverpos;//服务器发送回pos的数据
    public string serverstrwall;//服务器发送回wall的数据

    //public Text txtstr;//ui显示发送回来的数据


    public InputField textinput;
    public static Socket socket;

    public const int buffsize = 1024;
    public static byte[] readbuff = new byte[buffsize];
    //private void Start()
    //{
    //        public GameObject bunext;
    ////public InputField hostinput;

    ////显示客户端接收的消息
    ////public Text connecttext;
    //public string serverstr;//服务器发送回的数据

    ////public Text txtstr;//ui显示发送回来的数据

    ////public InputField textinput;

    //const int buffsize = 1024;
    //public byte[] readbuff = new byte[buffsize];
    private void Start()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string host = "192.168.43.84";
        IPAddress ipAdr = IPAddress.Parse(host);
        int port = 1989;
        try
        {
            socket.Connect(ipAdr, port);
        }
        catch
        {
            print("手机客户端连接失败");
        }

    }
    private void Update()
    {
        
    }
    public void getwall()
    {

        socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb1, null);
        while (serverstrwall == "")
        {
            socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb1, null);
        }
        Debug.Log("SERVERWALL的值为" + serverstrwall);
    }
    //public void getpos()
    //{

    //    socket.Receive(readbuff);
    //    string str = System.Text.Encoding.UTF8.GetString(readbuff, 0,buffsize);
    //    serverpos = str;
    //    Debug.Log("getposdiaoyong");
    //}
    //public void Receivecb(IAsyncResult ar)
    //{
    //    //serverpos = "";
    //    Debug.Log("receivecb");
    //    int count = socket.EndReceive(ar);

    //    string str = System.Text.Encoding.UTF8.GetString(readbuff, 0, count);

    //    serverpos = str;
    //    Debug.Log(str);
    //    Debug.Log(serverpos);
    //    socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb, null);

    //}
    public void getpos()
    {
        int bytes = socket.Receive(readbuff);
        string str = System.Text.Encoding.UTF8.GetString(readbuff, 0, bytes);


        serverpos = str;
        Debug.Log(str);
        Debug.Log(serverpos);
        //socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb, null);
        //Debug.Log("getposdiaoyong");
    }
    public void Receivecb(IAsyncResult ar)
    {
        //serverpos = "";
        Debug.Log("receivecb");
        int count = socket.EndReceive(ar);

        string str = System.Text.Encoding.UTF8.GetString(readbuff, 0, count);


        serverpos = str;
        Debug.Log(str);
        Debug.Log(serverpos);
        //socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb, null);

    }
    public void Receivecb1(IAsyncResult ar)
    {
        serverstrwall = "";

        int count = socket.EndReceive(ar);

        string str = System.Text.Encoding.UTF8.GetString(readbuff, 0, count);


        //Debug.Log(str);
        serverstrwall = str;
        //Debug.Log(serverstrwall);
        //socket.BeginReceive(readbuff, 0, buffsize, SocketFlags.None, Receivecb1, null);
    
    }

}


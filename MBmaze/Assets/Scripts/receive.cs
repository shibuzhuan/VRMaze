using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receive : MonoBehaviour
{

    //public GameObject conn;

    //private string posdata;
    //private string x, y, z;
    //private float posx, posy, posz;
    //private float posaaaaaa;
    //public GameObject player;

    //private void Awake()
    //{
    //    //conn.GetComponent<Client>().getpos();
    //}
    //void Start()
    //{
    //    posx = 5.0f;
    //    posy = 5.0f;
    //    posz = 5.0f;
    //    conn.GetComponent<Client>().getpos();
    //    player.transform.position = new Vector3(posx, posy, posz);
    //    posaaaaaa = Convert.ToSingle("10.25") * 10;
    //    Debug.Log(posaaaaaa);
    //    Debug.Log("初始位置" + posx + posy + posz);

    //    jieshou();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    conn.GetComponent<Client>().getpos();
    //    jieshou();


    //}
    //public void jieshou()

    //{
    //    //conn.GetComponent<Client>().getpos();
    //    posdata = conn.GetComponent<Client>().serverpos;
    //    Debug.Log(posdata);
    //    DOposition(posdata);
    //    posx = Convert.ToSingle(x);
    //    posy = Convert.ToSingle(y);
    //    posz = Convert.ToSingle(z);
    //    player.transform.position = new Vector3(posx, posy, posz);
    //    Debug.Log("现在位置" + posx + posy + posz);

    //}
    //public void DOposition(string s)
    //{
    //    x = "";
    //    y = "";
    //    z = "";
    //    print(s);
    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        if (s[i] == 'x')
    //        {
    //            for (int j = i + 1; j < s.Length; j++)
    //            {
    //                if (s[j] != 'y')
    //                {
    //                    //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
    //                    x = string.Join("", x, s[j]);
    //                }
    //                else break;


    //            }
    //        }
    //        if (s[i] == 'y')
    //        {
    //            for (int j = i + 1; j < s.Length; j++)
    //            {
    //                if (s[j] != 'z')
    //                {
    //                    //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
    //                    y = string.Join("", y, s[j]);
    //                }
    //                else break;


    //            }
    //        }
    //        if (s[i] == 'z')
    //        {
    //            for (int j = i + 1; j < s.Length; j++)
    //            {
    //                if (s[j] != 'x')
    //                {
    //                    //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
    //                    z = string.Join("", z, s[j]);
    //                }
    //                else break;


    //            }
    //        }


    //    }

    //  }
    public GameObject conn;

    private string posdata;
    private string x, y, z;
    private float posx, posy, posz;
    private float posaaaaaa;
    public GameObject player;

    private void Awake()
    {
        //conn.GetComponent<Client>().getpos();
    }
    void Start()
    {
        posx = 5.0f;
        posy = 5.0f;
        posz = 5.0f;
        //conn.GetComponent<Client>().getpos();
        player.transform.position = new Vector3(posx, posy, posz);
        posaaaaaa = Convert.ToSingle("10.25") * 10;
        Debug.Log(posaaaaaa);
        Debug.Log("初始位置" + posx + posy + posz);

        jieshou();
    }

    // Update is called once per frame
    void Update()
    {
        jieshou();

        //posdata = conn.GetComponent<connection>().serverpos;
        //Debug.Log(posdata);
        //
        //posx = Convert.ToSingle(x);
        //posy = Convert.ToSingle(y);
        //posz = Convert.ToSingle(z);
        //posaaaaaa= Convert.ToSingle("10.25");
        //Debug.Log(posx * 10);
        //player.transform.position = new Vector3(posx, posy, posz);
        //Debug.Log("现在位置" + posx + posy + posz);
    }
    public void jieshou()

    {
        conn.GetComponent<Client>().getpos();
        posdata = conn.GetComponent<Client>().serverpos;
        Debug.Log(posdata);
        DOposition(posdata);
        posx = Convert.ToSingle(x);
        posy = Convert.ToSingle(y);
        posz = Convert.ToSingle(z);
        player.transform.position = new Vector3(posx, posy, posz);
        Debug.Log("现在位置" + posx + posy + posz);
    }
    public void DOposition(string s)
    {
        x = "";
        y = "";
        z = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'x')
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j] != 'y')
                    {
                        //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
                        x = string.Join("", x, s[j]);
                    }
                    else break;


                }
            }
            if (s[i] == 'y')
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j] != 'z')
                    {
                        //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
                        y = string.Join("", y, s[j]);
                    }
                    else break;


                }
            }
            if (s[i] == 'z')
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j] != 'x')
                    {
                        //if ((int)s[j] <= 57 && (int)s[j] >= 48 || s[j] == 46)
                        z = string.Join("", z, s[j]);
                    }
                    else break;


                }
            }


        }
    }
}


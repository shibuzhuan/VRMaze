using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sendpos : MonoBehaviour
{
    public GameObject player;
    private string posstr;
    public GameObject conn;
    public bool issend = false;
    void Start()
    {

        // Debug.Log(Convert.ToSingle(a) * 10.0);

        //DOposition(possssssss); 
        //beginsend();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = player.GetComponent<Transform>().position;
        //string a = pos.x.ToString();
        //Debug.Log(a);
        if (issend == true)
        {
            posstr = GetPOS(player);
            Sendposstr(posstr);
        }



    }
    private string GetPOS(GameObject p)
    {
        Vector3 pos = p.GetComponent<Transform>().position;
        string str = "x" + pos.x.ToString() + "y" + pos.y.ToString() + "z" + pos.z.ToString();
        Debug.Log(posstr);
        return str;
    }
    public void beginsend()
    {
        issend = true;
    }
    public void stopsend()
    {
        issend = false;
    }
    public void Sendposstr(string s)
    {
        conn.GetComponent<Client>().Send(s);
        Debug.Log("FASONGWEIZZHI");
    }
}

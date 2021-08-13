using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ReadXml : MonoBehaviour
{
    string address;
    public string xmladress;
    public string wallData;
    public GameObject conn;
    // Start is called before the first frame update
    void Start()
    {
        

        xmladress = "C:\\walls.xml";
        if (System.IO.File.Exists(xmladress))
        {
            address = xmladress;
        }
        wallData = "";
        XmlDocument xm = new XmlDocument();
        float x = 0f;
        float y = 0f;
        if (File.Exists(address))
        {
     
            xm.Load(address);
            XmlNodeList xmlist = xm.SelectSingleNode("root").ChildNodes;
            wallData += "%";
            foreach (XmlElement xl3 in xmlist)
            {
           
                wallData += "*#";
                foreach (XmlElement xl2 in xl3.ChildNodes)
                {
                    if (xl2.Name == "x")
                    {
                        x = Convert.ToSingle(xl2.InnerText);
                    }
                    if (xl2.Name == "y")
                    {

                        y = Convert.ToSingle(xl2.InnerText);
                    }
                }
                wallData += x.ToString();
                wallData += "#";
                wallData += y.ToString();
                wallData += "#";
                wallData += "+";
            }
            wallData += "@";
        }
        conn.GetComponent<Client>().Send(wallData);
    }
   
    // Update is called once per frame
    void Update()
    {
    }
}

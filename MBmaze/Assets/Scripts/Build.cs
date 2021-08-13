using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject conn;
    private string serverstr;
    private string walldata;
    public bool beginrecivewall;
    public GameObject wall;//预设体wall；
    // Start is called before the first frame update
    void Start()
    {
        //conn.GetComponent<connection>().getwall();
        
        //Debug.Log("walldata"+walldata);
        
    }
    public void onclick()
    {
        
        //walldata = conn.GetComponent<connection>().serverstrwall
        conn.GetComponent<Client>().getwall();
        walldata = conn.GetComponent<Client>().serverstrwall;
        print("server" + conn.GetComponent<Client>().serverstrwall);
        dowall(walldata);
    }
    private int[] a = new int[100];
    public void dowall(string walld)
    {
        Debug.Log("walldatadowall" + walldata);

        int index = 0;
        bool flag = false;
        for (int i = 0; i < walld.Length; i++)
        {
            if (walld[i] == '%')
            {
                flag = true;
            }

            if (flag == true)
            {
                if ((int)walld[i] <= 57 && (int)walld[i] >= 48)
                {
                    if ((int)walld[i + 1] <= 57 && (int)walld[i + 1] >= 48)
                    {
                        a[index] = 10 * (walld[i] - 48) + (walld[i + 1] - 48);
                        index++;
                    }
                    else if ((int)walld[i - 1] >= 57 || (int)walld[i - 1] <= 48)
                    {
                        a[index] = walld[i] - 48;
                        index++;
                    }
                }
            }
        }
        wallbuild(a);

    }

    private void wallbuild(int[] arr)
    {
        for (int i = 0; i < arr.Length; i = i + 2)
        {
            if (arr[i] != 0)
            {
                if (arr[i] % 10 == 0)
                {
                    //f放置wallz在(arr[i],5,arr[i+1])
                    Vector3 pos = new Vector3(arr[i], 5, arr[i + 1]);
                    Vector3 rot = new Vector3(0, 0, 0);
                    Instantiate(wall, pos, Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Vector3 pos = new Vector3(arr[i], 5, arr[i + 1]);
                    Instantiate(wall, pos, Quaternion.Euler(0, 0, 0));


                    //f放置wallx在(arr[i],5,arr[i+1])

                }
            }
        }

    }


}

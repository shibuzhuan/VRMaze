using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour
{
    public GameObject w;
    public GameObject wall;
    private int[] a = new int[100];
    void Start()
    {
        string wall = w.GetComponent<ReadXml>().wallData;


        //生成位置信息数组
        int index = 0;
        for (int i = 0; i < wall.Length; i++)
        {
            if ((int)wall[i] <= 57 && (int)wall[i] >= 48)
            {
                if ((int)wall[i + 1] <= 57 && (int)wall[i + 1] >= 48)
                {
                    a[index] = 10 * (wall[i] - 48) + (wall[i + 1] - 48);
                    index++;
                }
                else if ((int)wall[i - 1] >= 57 || (int)wall[i - 1] <= 48)
                {
                    a[index] = wall[i] - 48;
                    index++;
                }
            }
        }

        wallbuild(a);





    }
    public void wallbuild(int[] arr)
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

    // Update is called once per frame
    void Update()
    {

    }
}

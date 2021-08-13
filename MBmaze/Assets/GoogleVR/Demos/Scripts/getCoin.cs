using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class getCoin : MonoBehaviour
{
    //public GameObject player;
    public GameObject coin;
    public GameObject awall;
    static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 5)
        {
            awall.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        // Debug.Log("123");
        Destroy(coin);
        count++;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            Debug.Log("gg bro");

        }
    }
}
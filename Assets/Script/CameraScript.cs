using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    public Vector3 direction;

    public void Start () 
    {
        player=GameObject.FindGameObjectWithTag("Player");
        //offset = new Vector3(-1.71f,0.92f,0); //On donne une position spécifique à la caméra vis-à-vis de la balle
    }

    private void Update()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        //transform.position = player.transform.position + offset;
        if(Input.GetKey("q"))
        {
            transform.RotateAround(player.transform.position,Vector3.up,-5);
        }
        if(Input.GetKey("d"))
        {
            transform.RotateAround(player.transform.position,Vector3.up,5);
        }
        direction=new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
    }
}


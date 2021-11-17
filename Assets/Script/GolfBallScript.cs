using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float Force;
    private Rigidbody rb;
    private GameObject camera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        camera=GameObject.FindGameObjectWithTag("Camera");
        if(Input.GetKeyDown("space"))
        {
            Putting();
        }
    }

    private void Putting()
    {
        rb.AddForce(camera.transform.forward.normalized*Force);
    }
}

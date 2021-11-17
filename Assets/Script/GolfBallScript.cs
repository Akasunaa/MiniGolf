using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float Force;
    private Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Putting();
        }
    }

    private void Putting()
    {
        rb.AddForce(new Vector3(10,0,0).normalized*Force);
    }
}

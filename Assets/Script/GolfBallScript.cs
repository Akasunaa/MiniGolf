using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float force;
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
        if (Input.GetKeyDown("r"))
        {
            Die();
        }
    }

    private void Putting()
    {
        rb.AddForce(camera.transform.forward.normalized*force);
    }

    public void Die()
    {
        FindObjectOfType<StartManager>().StartPlayerRespawn();
        Destroy(gameObject);
    }
}

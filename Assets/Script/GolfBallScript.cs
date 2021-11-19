using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float force;
    private Rigidbody rb;
    private GameObject camera;
    private GameObject floor;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        GameObject start = GameObject.FindWithTag("Respawn");
        print(start);
        transform.position = start.transform.position;
    }

    private void Update()
    {
        camera=GameObject.FindGameObjectWithTag("Camera");
        floor=GameObject.FindGameObjectWithTag("Floor");
        if(Input.GetKeyDown("space"))
        {
            Putting();
        }
        if (Input.GetKeyDown("r"))
        {
            Die();
        }
        if(transform.position.y<floor.transform.position.y-20)
        {
            Die();
        }
        if(rb.velocity.magnitude < 4)
        {
            rb.velocity=new Vector3(0,0,0);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float force;
    private Rigidbody rb;
    private GameObject camera;
    private GameObject floor;
    [SerializeField] private Vector3 jump = new Vector3(0, 5,0);

    //jump if is moving

    private bool isMoving;
    private bool canJump;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        GameObject start = GameObject.FindWithTag("Respawn");
        transform.position = start.transform.position;
        isMoving = false;
        canJump = false;

    }

    private void Update()
    {
        if (rb.velocity.magnitude >0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        camera =GameObject.FindGameObjectWithTag("Camera");
        floor=GameObject.FindGameObjectWithTag("Floor");
        if(Input.GetKeyDown("space"))
        {
            if (isMoving && canJump)
            {
                Jump();
                print("ismoving and canjump");
            }
            else if (!isMoving) {
                Putting();
                print("notmoving ");
            }
            else {
                print("ismoving and notjump");
            }
            
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

    private void Jump()
    {
        rb.velocity += jump;
        canJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {

        if ((collision.gameObject.tag == "Floor"))
        {
            canJump = true;
            print("WOAAAAA");
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float force;
    private Rigidbody rb;
    private GameObject camera;
    private GameObject floor;
    [SerializeField] private Vector2 jump = new Vector2(0, 5);

    //jump if is moving

    private bool isMoving;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        GameObject start = GameObject.FindWithTag("Respawn");
        print(start);
        transform.position = start.transform.position;
        isMoving = false;

    }

    private void Update()
    {
        if (transform.hasChanged)
        {
            isMoving = true;
            transform.hasChanged = false;

        }
        else
        {
            isMoving = false;
        }

        camera =GameObject.FindGameObjectWithTag("Camera");
        floor=GameObject.FindGameObjectWithTag("Floor");
        if(Input.GetKeyDown("space"))
        {
            print(isMoving);
            if (isMoving){
                Jump();
                print("jump");
            }
            else {
                Putting();
                print("putting");
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
        rb.velocity = jump;
    }

    
}

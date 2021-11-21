using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UI;


public class GolfBallScript : MonoBehaviour
{
    [SerializeField] float force;
    private Rigidbody rb;
    private GameObject camera;
    private GameObject floor;
    //public Canvas canva;
    GameObject multtext;
    
    private GameObject start;
    [SerializeField] private Vector3 jump = new Vector3(0, 5, 0);

    

    //jump if is moving

    private bool isMoving;
    private bool canJump;

    //force with time push

    private float downTime;
    private float upTime;
    private float currentTime;
    private float startTime = 0f;

    int time;

    public Vector3 spawn;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        start = GameObject.FindWithTag("Respawn");
        floor = GameObject.FindGameObjectWithTag("Floor");
        camera = GameObject.FindGameObjectWithTag("Camera");
        transform.position = start.transform.position;
        isMoving = false;
        canJump = false;
        //multtext = canva.transform.GetChild(1);
        multtext = GameObject.FindGameObjectWithTag("Mult");
        multtext.GetComponent<TMPro.TextMeshProUGUI>().text = "x0";
        time = 0;
        

    }

    private void Update()
    {

        IsMoving();
        
        Timer();
        TimerInput();
        PutAndJump();




        if (Input.GetKeyDown("r"))
        {
            Die();
        }
        if (transform.position.y < floor.transform.position.y - 20)
        {
            Die();
        }
        if (rb.velocity.magnitude < 4)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void Putting()
    {
        spawn = transform.position;
        if ((int)currentTime > 5)
        {
            currentTime = 5;
        }
        rb.AddForce(camera.transform.forward.normalized * force * ((int)currentTime + 1));
        
    }

    public void Die()
    {
        
        FindObjectOfType<StartManager>().StartPlayerRespawn(spawn);
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

    void IsMoving()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void PutAndJump()
    {
        if (Input.GetKeyUp("space"))
        {
            if (isMoving && canJump)
            {
                Jump();
                print("ismoving and canjump");
            }
            else if (!isMoving)
            {
                Putting();
                print("notmoving ");
            }
            else
            {
                print("ismoving and notjump");
            }

        }
    }

    //poubelle
    void TimerInput2()
    {
        float time = Time.time;
        float timee = 0;
        while (Input.GetKey("space"))
        {
            timee = Time.time - time;
        }

        print(timee);
    }
    //ceci sert à rien mais en fait si parce que je suis nul 
    void TimerInput()
    {
        currentTime = 0;
        if (Input.GetKeyDown("space"))
        {
            downTime = Time.time;
        }
        if (Input.GetKeyUp("space"))
        {
            upTime = Time.time;
            currentTime = upTime - downTime;
        }

    }

    
    void Timer()
    {
        //float startTime = 0;
        


        if (Input.GetKeyDown("space"))
        {
            startTime = Time.time;
            print(startTime);
            time = 0;
        }


        if (Input.GetKey("space"))
        {
            int loop = 0;
            //startTime = Time.time;
            while (startTime + time <= Time.time && loop <= 4)
            {
                //multtext.text = time.ToString();
                time += 1;
                multtext.GetComponent<TMPro.TextMeshProUGUI>().text = ("x" + time.ToString());
                loop += 1;
            }
            time = 0;
            //multtext.GetComponent<TMPro.TextMeshProUGUI>().text = ("x" + time.ToString());
        }
        else if (Input.GetKeyUp("space"))
        {
            time = 0;
            multtext.GetComponent<TMPro.TextMeshProUGUI>().text = ("x" + time.ToString());
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    GameObject player;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            return;
        transform.position = player.transform.position;
    }
}

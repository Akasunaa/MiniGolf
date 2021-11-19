using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    
    [SerializeField] private Vector3 Axe;
    //[SerializeField] private Vector3 Speed;

    void Update()
    {
        transform.Rotate(Axe*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRota : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float hiz;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * hiz;
    }

    
}

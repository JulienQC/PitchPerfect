using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody body;
    private bool isCentered;
    
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GravityCenter"))
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            transform.position = new Vector3(0, 1, 0);
            isCentered = true;
        }
    }


    public void Attract(Vector3 force)
    {
        if (isCentered)
        {
            ApplyForce(force);
            isCentered = false;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        body.AddForce(force, ForceMode.Force);
    }
}

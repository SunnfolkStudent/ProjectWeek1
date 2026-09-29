using System;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpSpeed;
    
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (transform)
        {
            print("bounced");
            rb.linearVelocityY = jumpSpeed * 1.8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    
    
    
}

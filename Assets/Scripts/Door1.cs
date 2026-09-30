using System;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            _rigidbody2D.linearVelocityX = moveSpeed * -1;
        }
    }
    
}

using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            if (transform.position.x <= -0.1)
                _rigidbody2D.linearVelocityX = moveSpeed * -1;
            else
                _rigidbody2D.linearVelocityX = moveSpeed;
        }
    }
    
}

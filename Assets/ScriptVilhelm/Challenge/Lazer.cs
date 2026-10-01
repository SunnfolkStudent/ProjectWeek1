using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float despawnTime = 1f;

    public Rigidbody2D _rigidbody2D;

    void Start()
    {
        Destroy(gameObject, despawnTime);
        _rigidbody2D.linearVelocity = new Vector2(1f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    
}

    


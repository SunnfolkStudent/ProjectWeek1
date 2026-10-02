using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float despawnTime = 3f;

    public Rigidbody2D _rigidbody2D;

    void Start()
    {
        Destroy(gameObject, despawnTime);
        //_rigidbody2D.linearVelocity = new Vector2(1f, 0f) * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        print(collision.gameObject.name);
    }
    
    
    
}

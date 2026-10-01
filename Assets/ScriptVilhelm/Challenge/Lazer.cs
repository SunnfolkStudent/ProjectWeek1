using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float despawnTime = 1f;

    public Rigidbody2D _rigidbody2D;

    void Start()
    {
        Destroy(gameObject, despawnTime);
    }
}

    


using System;
using UnityEngine;

public class PistolEnemie : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float timer;
    public float maxWaittime = 2f;

    void Start()
    {
        timer = maxWaittime;
    }
    
    
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else
        {
           var clone = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
           
           clone.TryGetComponent(out Rigidbody2D rb);
           
           rb.linearVelocity = new Vector2(1f*transform.localScale.x, 0f) *5f;
           Destroy(clone, 2f);
           
            timer = maxWaittime;
        }
        
        
    }
}

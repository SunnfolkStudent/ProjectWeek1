using System;
using TMPro;
using UnityEngine;

public class PistolEnemie : MonoBehaviour
{
    private Animator _animator;
    
    public GameObject bullet;
    public Transform bulletSpawn;

    public float timer;
    public float maxWaittime = 2f;

    void Start()
    {
        timer = maxWaittime;
        _animator = GetComponent<Animator>();
    }
    
    
    void Update()
    {
        
    }

    public void shoot()
    {
        var clone = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
           
        clone.TryGetComponent(out Rigidbody2D rb);
           
        rb.linearVelocity = new Vector2(1f*transform.localScale.x, 0f) *5f;
        Destroy(clone, 2f);
           
        timer = maxWaittime;
    }
}
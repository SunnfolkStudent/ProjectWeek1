using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RayEnemie : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public float timer;
    public float maxWaittime = 4f;
    
    private Animator _animator;

    void Start()
    {
        timer = maxWaittime;
        _animator = GetComponent<Animator>();
        _animator.StopPlayback();
    }
    
    
    void Update()
    {
        if (timer > 0)
        { 
            timer -= Time.deltaTime;
        }
        else
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            timer = 3f;
        }
    }
    
}

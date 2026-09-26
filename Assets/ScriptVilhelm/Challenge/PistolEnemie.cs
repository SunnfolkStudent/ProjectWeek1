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
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            timer = maxWaittime;
        }
        
        
    }
}

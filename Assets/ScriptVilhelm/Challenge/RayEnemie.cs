using System;
using UnityEngine;
using System.Collections;

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
    }
    
    
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else
        {
            SpawnBullet();
        }
        
        
    }

    private IEnumerator SpawnBullet()
    {
        _animator.Play("Shrimp fire big");
        yield return new WaitForSeconds(0.2f);
        _animator.Play("BeamChargeUp");
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        _animator.Play("BEAAMM");
        timer = maxWaittime;
    }
}

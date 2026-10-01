using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RayEnemie : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public AudioClip sound;

    public float timer;
    public float maxWaittime = 4f;
    
    private Animator _animator;
    private  AudioSource _audioSource;

    void Start()
    {
        timer = maxWaittime;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _animator.StopPlayback();
    }
    
    
    void Update()
    {

    }

    private void Shoot()
    {
        Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        _audioSource.PlayOneShot(sound);
    }
    
}

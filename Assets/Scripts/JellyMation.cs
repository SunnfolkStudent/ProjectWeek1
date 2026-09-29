using System;
using Unity.VisualScripting;
using UnityEngine;

public class JellyMation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("idle");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetTrigger("bounce");
        }
    }
}

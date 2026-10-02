using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Random = UnityEngine.Random;

public class MovementController : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private AudioSource _audioSource;
    
    public float moveSpeed;
    public float jumpSpeed;
    public int health;

    public bool dying;
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsPickup;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);

    public GameObject heldObject;
    public Transform holdPosition;

    private Transform macGuffin;

    public float throwSpeed;
    
    public AudioClip[] jumpSounds;
    public AudioClip[] moveSounds;
    public AudioClip deathSound;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        health = 3;
        dying = false;
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (heldObject == null && _input.Jump && _input.Vertical < 0)
        {
            var hitInfo = Physics2D.OverlapCircle(transform.position, 1.5f, whatIsPickup);
            if (hitInfo != null)
            {
                hitInfo.TryGetComponent(out Rigidbody2D rb);
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                
                heldObject = hitInfo.gameObject;
                macGuffin = heldObject.transform;
                
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = transform;
            }
        }
        else if (heldObject != null && _input.Jump && _input.Vertical > 0)
        {
            // Throw Object
            heldObject.TryGetComponent(out Rigidbody2D rb);
            rb.constraints = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                
            rb.bodyType = RigidbodyType2D.Dynamic;
            heldObject.transform.parent = null;
            rb.linearVelocityY = throwSpeed * 1.8f;
            rb.linearVelocityX = throwSpeed * transform.localScale.x * -1;
            
            heldObject = null;
            
        }
        

        if (_input.Vertical == 0)
        {
            if (_input.Jump && playerIsGrounded && dying == false)
            {
                _rigidbody2D.linearVelocityY = jumpSpeed;
                int randomSound = Random.Range(0, jumpSounds.Length);
                _audioSource.PlayOneShot(jumpSounds[randomSound]);
            }
        }
        
      

        if (health <= 0)
        {
            StartCoroutine(FullyDie());
            SceneManager.LoadScene("GameOver");
        }

        UpdateAnimation();

        if (dying == false)
        {
            if (_input.Horizontal >= 1)
            { 
                transform.localScale = new Vector2(-1, 1);
            }
            else if (_input.Horizontal <= -1)
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (dying == false)
        {
            _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;   
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("BouncePad"))
        {
            _rigidbody2D.linearVelocityY = jumpSpeed * 1.4f;
        }
        
        if (other.transform.CompareTag("MegaPad"))
        {
            _rigidbody2D.linearVelocityY = jumpSpeed * 1.8f;
        }

        if (other.transform.CompareTag("Enemy") && dying == false)
        {
            StartCoroutine(Die());
        }

        if (other.transform.CompareTag("NextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && dying == false)
        {
            StartCoroutine(Die());
        }
        
        if (other.transform.CompareTag("Enemy") && dying == false)
        {
            StartCoroutine(Die());
        }
    }

    private void UpdateAnimation()
    {
        if (dying) return;
        
        if (playerIsGrounded)
        {
            if (_input.Horizontal != 0)
            {
                _animator.Play("walk left");
            }
            else 
            {
                _animator.Play("IDLE");
            }
        }
        else
        {
            if (_rigidbody2D.linearVelocityY > 0)
            {
                _animator.Play("jump up");
            }
            else
            {
                _animator.Play("jump down");
            }
        }
    }
    
    public void WalkAudio()
    {
        int randomSound = Random.Range(0, moveSounds.Length);
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(moveSounds[randomSound]);
    }

    private IEnumerator Die()
    {
        dying = true;
        health--;
        _audioSource.PlayOneShot(deathSound);
        _animator.Play("death animation");
        yield return new WaitForSeconds(1.75f);
        transform.position = new Vector3(0, -5.5f, -1);

        if (macGuffin != null)
        {
            macGuffin.TryGetComponent(out Macguffinit guffin);
            macGuffin.position = guffin.startingPoint;
        }

        if (heldObject != null)
        {
            heldObject.TryGetComponent(out Rigidbody2D rb);
            rb.constraints = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                
            rb.bodyType = RigidbodyType2D.Dynamic;
            
            heldObject.transform.parent = null;
            heldObject = null;
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        dying = false;
    }
    private IEnumerator FullyDie()
    {
        health--;
        dying = true;
        _animator.Play("death animation");
        yield return new WaitForSeconds(1.75f);
        Destroy(gameObject);
        transform.position = new Vector3(0, -5.5f, -1);
        dying = false;
        SceneManager.LoadScene("GameOver");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
        
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    public float moveSpeed;
    public float jumpSpeed;
    public int health;

    public bool dying;
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    public TextMeshProUGUI healthText;

    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject ReMainMenu;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        health = 3;
        healthText.text = "Lives: " + health;
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        ReMainMenu.SetActive(false);
        dying = false;
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded && dying == false)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }

        if (health <= 0)
        {
            StartCoroutine(FullyDie());
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
            print("bounced");
            _rigidbody2D.linearVelocityY = jumpSpeed * 1.8f;
        }

        if (other.transform.CompareTag("Enemy") && dying == false)
        {
            StartCoroutine(Die());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
            transform.position = new Vector3(0, -2, -1);
            healthText.text = "Lives: " + health;
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
                _animator.Play("jump1");
            }
            else
            {
                _animator.Play("jumpFall");
            }
        }
    }

    private IEnumerator Die()
    {
        dying = true;
        health--;
        healthText.text = "Lives: " + health;
        _animator.Play("death animation");
        yield return new WaitForSeconds(1.75f);
        transform.position = new Vector3(0, -5.5f, -1);
        dying = false;
    }
    private IEnumerator FullyDie()
    {
        health--;
        healthText.text = "Lives: " + health;
        dying = true;
        _animator.Play("death animation");
        yield return new WaitForSeconds(1.75f);
        Destroy(gameObject);
        transform.position = new Vector3(0, -5.5f, -1);
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        ReMainMenu.SetActive(true);
        dying = false;
    }
}

using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed;
    public float jumpSpeed;
    public int health;
    
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);
    public TextMeshProUGUI healthText;

    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject ReMainMenu;
    public GameObject Background;

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        health = 3;
        healthText.text = "Lives: " + health;
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        ReMainMenu.SetActive(false);
        Background.SetActive(false);
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
        }

        if (health <= 0)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            ReMainMenu.SetActive(true);
            Background.SetActive(true);
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("BouncePad"))
        {
            print("bounced");
            _rigidbody2D.linearVelocityY = jumpSpeed * 1.8f;
        }

        if (other.transform.CompareTag("Enemy"))
        {
            health--;
            transform.position = new Vector3(0, -2, 0);
            healthText.text = "Lives: " + health;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
            transform.position = new Vector3(0, -2, 0);
            healthText.text = "Lives: " + health;
        }
    }
}

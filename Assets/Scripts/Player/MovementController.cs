using UnityEngine;

public class MovementController : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    
    public float moveSpeed;
    public float jumpSpeed;
    
    public bool playerIsGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);

    private void Start()
    {
        _input = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerIsGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
        
        if (_input.Jump && playerIsGrounded)
        {
            _rigidbody2D.linearVelocityY = jumpSpeed;
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
    }
}

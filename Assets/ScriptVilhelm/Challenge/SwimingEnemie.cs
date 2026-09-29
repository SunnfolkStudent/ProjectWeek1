using UnityEngine;

public class SwimingEnemie : MonoBehaviour
{
    public float moveSpeed;
    
    public LayerMask whatisWall;
    public Transform wallCheck;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.Play("swimming");
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }
    
    
    private bool DetectedWallOrFall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatisWall);
    }

  
    private void Update()
    {
        if (DetectedWallOrFall())
        {
            moveSpeed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
    }
    
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(wallCheck.position, 0.1f);
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}

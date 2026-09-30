using UnityEngine;

public class CrabEnemie : MonoBehaviour
{
    public float moveSpeed;
    
    public LayerMask whatisWall;
    public Transform wallCheck;
    public Transform fallCheck;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animator.Play("Crab Walk");
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }
    
    
    private bool DetectedWallOrFall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatisWall) ||
               !Physics2D.OverlapCircle(fallCheck.position, 0.1f, whatisWall);
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
        Gizmos.DrawWireSphere(fallCheck.position, 0.1f);
    }


}

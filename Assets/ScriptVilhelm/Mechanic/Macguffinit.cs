using System;
using UnityEngine;

public class Macguffinit : MonoBehaviour

{
	private Rigidbody2D _rigidbody2D;
	public float jumpSpeed;

	public bool isMacguffinGrounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public Vector2 groundBoxSize = new Vector2(0.8f, 0.2f);

	public Vector2 startingPoint;
	
	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		startingPoint = transform.position;
	}

	private void Update()
	{
		isMacguffinGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, 0f, whatIsGround);
		if (isMacguffinGrounded)
		{
			//_rigidbody2D.linearVelocityY = jumpSpeed;
		}
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("BouncePad"))
		{
			print("bounced");
			_rigidbody2D.linearVelocityY = jumpSpeed * 2f;
		}
		if (other.transform.CompareTag("MegaPad"))
		{
			_rigidbody2D.linearVelocityY = jumpSpeed * 1.2f;
		}
		
		
		
	}
	
	
	
}
	


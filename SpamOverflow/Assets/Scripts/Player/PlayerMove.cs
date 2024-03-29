using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;

	public Transform groundCheck;
	private LayerMask groundLayer;
	private LayerMask plataformLayer;

	private float horizontalInput;
	private float verticalInput;
	public float speed = 8f;
	public float jumpForce;
	public float coyoteTime = 0.15f;
	private float groundCheckRadius = 0.025f;
	public float jumpBufferTime = 0.15f;

	private Vector2 movement;

	private bool _isGrounded;
	private bool _isPassingThrough;
	private bool _facingRight;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
		groundLayer = LayerMask.GetMask("Ground");
		plataformLayer = LayerMask.GetMask("Spam Plat");
	}

	void Update() {
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
		movement = new Vector2(horizontalInput, verticalInput);
		
		Jump();
		Flip();
		PassThrough();
	}
	private void FixedUpdate() {
		Move();
	}

	private IEnumerator AllowPassThrough() {
		_isPassingThrough = true;
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlataform"), true);

		yield return new WaitForSeconds(0.3f);

		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlataform"), false);
		_isPassingThrough = false;
	}

	private void Move() {
		rb.velocity = new Vector2(movement.normalized.x * speed, rb.velocity.y);
	}

	private void Flip() {
		if (horizontalInput < 0f && !_facingRight || horizontalInput > 0f && _facingRight)
		{
			_facingRight = !_facingRight;
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}		
	}

	private void Jump() {
		_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer | plataformLayer);

		if (_isGrounded)
			coyoteTime = 0.15f;
		else
			coyoteTime -= Time.deltaTime;

		if (Input.GetButtonDown("Jump") && verticalInput >= 0)
			jumpBufferTime = 0.15f;	
		else
			jumpBufferTime -= Time.deltaTime;

		if (jumpBufferTime > 0f && coyoteTime > 0f) 
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			coyoteTime = 0f;
		}
		//Jump more or less
		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
			coyoteTime = 0f;
		}
	}

	private void PassThrough() {
		if (verticalInput < 0 && Input.GetButtonDown("Jump") && _isGrounded && !_isPassingThrough)
			StartCoroutine(AllowPassThrough());
	}
}

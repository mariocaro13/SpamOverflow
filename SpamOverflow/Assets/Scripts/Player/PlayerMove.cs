using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rb;

	public Transform groundCheck;
	private LayerMask groundLayer;
	private LayerMask plataformLayer;
	private LayerMask playerLayer;

	private float horizontalInput;
	public float speed = 8f;
	public float jumpForce = 2.5f;
	public float coyoteTime = 0.15f;
	private float groundCheckRadius = 0.025f;
	private float coyoteTimeCounter;
	public float jumpBufferTime = 0.15f;
	private float jumpBufferCounter;

	private Vector2 movement;

	private bool _isGrounded;
	private bool _isPassingThrough;
	private bool _facingRight;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		groundLayer = LayerMask.GetMask("Ground");
		plataformLayer = LayerMask.GetMask("OneWayPlataform");
		playerLayer = LayerMask.GetMask("Player");
	}

	void Update()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
		movement = new Vector2(horizontalInput, verticalInput);

		_isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer | plataformLayer);

		if (_isGrounded == true)
		{
			coyoteTimeCounter = coyoteTime;
		}
		else
		{
			coyoteTimeCounter -= Time.deltaTime;
		}

		if (Input.GetButtonDown("Jump") && !(Input.GetAxisRaw("Vertical") < 0))
		{
			jumpBufferCounter = jumpBufferTime;
		}
		else
		{
			jumpBufferCounter -= Time.deltaTime;
		}

		if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);

			coyoteTimeCounter = 0f;
		}

		// Jump more ore less if hold (Como funciona???)
		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

			coyoteTimeCounter = 0f;
		}

		if (horizontalInput < 0f && _facingRight == false)
		{
			Flip();
		}
		else if (horizontalInput > 0f && _facingRight == true)
		{
			Flip();
		}

		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetButtonDown("Jump") && _isGrounded && !_isPassingThrough)
		{
			StartCoroutine(AllowPassThrough());
		}

	}
	private IEnumerator AllowPassThrough()
	{
		_isPassingThrough = true;
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlataform"), true);
		yield return new WaitForSeconds(0.3f); // Espera 0.5 segundos
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("OneWayPlataform"), false);
		_isPassingThrough = false;
	}

	private void Flip()
	{
		_facingRight = !_facingRight;
		float localScaleX = transform.localScale.x;
		localScaleX = localScaleX * 1f;
		transform.localScale = new Vector3(localScaleX * -1f, transform.localScale.y, transform.localScale.z);
	}

	private void FixedUpdate()
	{
		float horizontalVelocity = movement.normalized.x * speed;
		float verticalVelocity = movement.normalized.y * speed;

		// Por ahora, ya que habria que añadir la vel de plataforma si hubise
		rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
	}
}

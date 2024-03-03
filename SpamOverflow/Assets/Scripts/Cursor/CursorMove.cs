using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
	private Vector3 mousePosition;
	[HideInInspector] public Vector2 velocity;

	public float moveSpeed = 100f;

	[HideInInspector] public Rigidbody2D rb;
	private Animator animator;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		Cursor.visible = false;
		mousePosition = transform.position;
	}

	private void FixedUpdate()
	{
		//mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//direction = (mousePosition - transform.position).normalized;
		//rb.velocity = direction * moveSpeed;


		//Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.position = new Vector2(cursorPos.x, cursorPos.y);


		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = cursorPos;

		// Calcula la velocidad basada en el cambio de posición
		velocity = (transform.position - mousePosition) / Time.deltaTime;
		mousePosition = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Spam Plat"))
		{
			animator.SetBool("_isTouching", true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Spam Plat"))
		{
			animator.SetBool("_isTouching", false);
		}
	}
}

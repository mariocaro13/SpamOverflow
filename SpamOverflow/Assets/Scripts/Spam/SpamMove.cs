using System.Linq.Expressions;
using UnityEngine;

public class SpamMove : MonoBehaviour
{
	private Rigidbody2D rb;
	private GameObject Cursor;
	private CursorMove cursorMove;
	private Color c_default;
	private Color c_onAction;

	[SerializeField] private bool _amIPalatform;
	private bool _canMove;
	private bool _isTouchingCursor;
	private bool _isTouchingPlayer;

	public string s_colorDefault;
	public string s_colorOnAction;

	private float speed = 1f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		Cursor = GameObject.Find("Cursor");
		cursorMove = Cursor.GetComponent<CursorMove>();

		if (_amIPalatform)
		{
			c_default = HexToColor(s_colorDefault);
			c_onAction = HexToColor(s_colorOnAction);
		}
	}

	private void Update()
	{
		if (_isTouchingCursor && !_isTouchingPlayer && Input.GetMouseButtonDown(0))
			_canMove = true;
		
		if (Input.GetMouseButtonUp(0) || _isTouchingPlayer)
		{
			_canMove = false;
			rb.velocity = Vector3.zero;
		}

		if (!_amIPalatform)
			_isTouchingPlayer = false;

		Move();
	}

	private void Move()
	{
		if (_canMove)
			rb.velocity = cursorMove.velocity * speed;	
	}

	private void ChangeColor(Color color)
	{
		GetComponent<Renderer>().material.color = color;
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		return new Color(r / 255f, g / 255f, b / 255f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Cursor"))
			_isTouchingCursor = true;

		if (collision.gameObject.CompareTag("Player") && _amIPalatform)
		{
				ChangeColor(c_onAction);
				_isTouchingPlayer = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Cursor"))
			_isTouchingCursor = false;

		if (collision.gameObject.CompareTag("Player") && _amIPalatform)
		{
			ChangeColor(c_default);
			_isTouchingPlayer = false;		
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && _canMove && _amIPalatform)
		{
			Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
			playerRb.velocity = Vector2.zero;
		}
	}
}

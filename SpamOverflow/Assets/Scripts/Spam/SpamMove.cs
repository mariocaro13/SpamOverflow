using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamMove : MonoBehaviour
{
	private float spamSpeed = 1f;

	private bool _cursorIN;
	private bool _spamMove;
	public bool _touchPlay;
	public bool _isOver;

	private Rigidbody2D rb;
	private CursorMove cursorMove;
	private GameObject Cursor;

	public string colorHexSiToca = "A9A9A9";
	public string colorHexSiNoToca = "0082FF";

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		Cursor = GameObject.Find("Cursor");
		cursorMove = Cursor.GetComponent<CursorMove>();
	}

	private void Update()
	{
		if (_cursorIN && !_touchPlay && Input.GetMouseButtonDown(0))
		{
			_spamMove = true;
		}
		else if (Input.GetMouseButtonUp(0) || _touchPlay)
		{
			_spamMove = false;
			rb.velocity = Vector3.zero;
		}

		if (_isOver)
		{
			_touchPlay = false;
		}

		MovSpam();

		ChangeColorCantMove();
	}

	private void MovSpam()
	{
		if (_spamMove)
		{
			//Debug.Log(cursorMov.rb.velocity);
			//rb.velocity = cursorMov.rb.velocity;

			rb.velocity = cursorMove.velocity * spamSpeed;
		}
	}

	private void ChangeColorCantMove()
	{
		Color colorSiToca = HexToColor(colorHexSiToca);
		Color colorSiNoToca = HexToColor(colorHexSiNoToca);

		if (_touchPlay)
		{
			GetComponent<Renderer>().material.color = colorSiToca;
		}
		else
		{
			GetComponent<Renderer>().material.color = colorSiNoToca;
		}
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
		{
			_cursorIN = true;
		}

		if (collision.gameObject.CompareTag("Player"))
		{
			if (!_isOver)
				_touchPlay = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Cursor"))
		{
			_cursorIN = false;
		}

		if (collision.gameObject.CompareTag("Player"))
		{
			_touchPlay = false;
		}
	}
}

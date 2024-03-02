using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
	public Transform A;
	public Transform B;
	public float fuerza = 5f;

	private Vector2 direction;

	private void Start()
	{
		direction = (A.position - B.position).normalized;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
			player.rb.velocity += new Vector2(fuerza, 0);
		}
	}
}

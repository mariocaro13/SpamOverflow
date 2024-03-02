using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
	public float force = 5f;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
			player.rb.velocity += new Vector2(force, 0);
		}
	}
}

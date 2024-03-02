using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOut : MonoBehaviour
{
	private Rigidbody2D rb;

	public Transform startPoint;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	public void ReSpawnOut()
	{
		rb.velocity = Vector2.zero;

		transform.position = startPoint.position;
	}
}

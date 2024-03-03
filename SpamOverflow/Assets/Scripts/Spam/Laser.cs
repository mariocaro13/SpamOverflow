using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private Vector2 targetDirection;
	public Vector2 currentDirection;

	public float trackingSpeed = 1f; // Velocidad a la que el láser sigue al jugador

	private GameObject player;
	private LineRenderer lineRenderer;

	private LayerMask groundLayer;
	private LayerMask playerLayer;
	private LayerMask plataformLayer;

	void Start()
	{
		player = GameObject.Find("Player");
		groundLayer = LayerMask.GetMask("Ground");
		playerLayer = LayerMask.GetMask("Player");
		plataformLayer = LayerMask.GetMask("Spam Plat");
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update()
	{
		// Calcula la dirección deseada hacia el jugador
		targetDirection = (player.transform.position - transform.position).normalized;

		// Suavemente ajusta la dirección actual hacia la dirección deseada
		currentDirection = Vector2.MoveTowards(currentDirection, targetDirection, trackingSpeed * Time.deltaTime);

		// Realiza un Raycast en la dirección actual suavizada
		RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, Mathf.Infinity, groundLayer | playerLayer | plataformLayer);

		if (hit.collider != null && hit.collider.CompareTag("Player"))
		{
			// Intenta enviar un mensaje al script del jugador
			hit.collider.gameObject.SendMessage("ReSpawnOut", SendMessageOptions.DontRequireReceiver);
		}

		// Asegúrate de que el raycast golpeó algo para evitar errores
		if (hit.collider != null)
		{
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, hit.point);
		}
		else
		{
			// En caso de que el raycast no golpee nada, simplemente extiende el láser en la dirección actual
			lineRenderer.SetPosition(0, transform.position);
			lineRenderer.SetPosition(1, transform.position + (Vector3)currentDirection * 100); // Usa una distancia arbitrariamente grande
		}
	}
}

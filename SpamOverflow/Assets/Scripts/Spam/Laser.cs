using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private Vector2 targetDirection;
	private Vector2 currentDirection;

	public float trackingSpeed = 1f; // Velocidad a la que el láser sigue al jugador

	private GameObject player;
	private LineRenderer lineRenderer;

	private LayerMask groundLayer;
	private LayerMask playerLayer;

	void Start()
	{
		player = GameObject.Find("Player");
		groundLayer = LayerMask.GetMask("Ground");
		playerLayer = LayerMask.GetMask("Player");
		lineRenderer = GetComponent<LineRenderer>();
		currentDirection = transform.right; // Inicializa con la dirección inicial del láser
	}

	void Update()
	{
		// Calcula la dirección deseada hacia el jugador
		targetDirection = (player.transform.position - transform.position).normalized;

		// Suavemente ajusta la dirección actual hacia la dirección deseada
		currentDirection = Vector2.MoveTowards(currentDirection, targetDirection, trackingSpeed * Time.deltaTime);

		// Realiza un Raycast en la dirección actual suavizada
		RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, Mathf.Infinity, groundLayer | playerLayer);

		if (hit.collider != null && hit.collider.CompareTag("Player"))
		{
			// Intenta enviar un mensaje al script del jugador
			hit.collider.gameObject.SendMessage("ReSpawnOut", SendMessageOptions.DontRequireReceiver);
			Debug.Log("Player hit by laser!"); // Confirmación de que el raycast detectó al jugador
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

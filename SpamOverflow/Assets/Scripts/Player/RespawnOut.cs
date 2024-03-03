using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOut : MonoBehaviour
{
	private Rigidbody2D rb;

	public Transform startPoint;

	private GameObject World;
	private WorldScript scriptWorld;

	private string sceneName;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		sceneName = SceneManager.GetActiveScene().name;

		World = GameObject.Find("World");
		scriptWorld = World.GetComponent<WorldScript>();
	}

	public void ReSpawnOut()
	{
		rb.velocity = Vector2.zero;

		transform.position = startPoint.position;

		scriptWorld.muertes++;

		SceneManager.LoadScene(sceneName);
	}  
}

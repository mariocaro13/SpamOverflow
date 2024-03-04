using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class WorldScript : MonoBehaviour
{
	private BoxCollider2D spawnArea;
	public static WorldScript instance;
	public GameObject spamDeadPrefab;
	public Transform parentObject;
	public int deadCount;

	void Awake()
	{
		spawnArea = GetComponent<BoxCollider2D>();

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		for (int i = deadCount; i > 0; i--)
			SpawnSpamDeads();
	}

	public void SpawnSpamDeads()
	{
		float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
		float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

		Instantiate(spamDeadPrefab, new Vector2(x, y), Quaternion.identity);
	}
}

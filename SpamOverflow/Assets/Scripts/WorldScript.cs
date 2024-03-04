using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScript : MonoBehaviour
{
	public static WorldScript instance;
	public int muertes;

	public bool _is = true;

	private BoxCollider2D spawnArea;
	public GameObject spamDeadPrefab;
	public Transform parentObject;

	private float contador;

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
		
		_is = true;
	}

	private void Update()
	{
		

		if (_is)
		{
			Bucle();
			 _is = false;
		}
	}

	private void Bucle()
	{
		int numEnemies = muertes;
		for (int i = 0; i < numEnemies; i++)
		{

			SpawnSpamDeads();
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

		Bucle();

	}

	public void SpawnSpamDeads()
	{
		float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
		float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

		Instantiate(spamDeadPrefab, new Vector2(x, y), Quaternion.identity);
	}
}

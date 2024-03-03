using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
	public static WorldScript instance;
	public int muertes;

	private BoxCollider2D spawnArea;
	public GameObject spamDeadPrefab;
	public Transform parentObject;

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

	public void SpawnSpamDeads()
	{
		float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
		float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

		GameObject spamDeadObject = Instantiate(spamDeadPrefab, new Vector2(x, y), Quaternion.identity);
		spamDeadObject.transform.SetParent(this.transform, true);
	}
}

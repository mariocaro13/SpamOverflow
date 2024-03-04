using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public float timerGame;
	private float timerLevel;
	public float timerMax;
	public float score;
	public float multiplaller;

	private bool _isGameOver;

	public GameObject GameOverCOntador;

	public TextMeshProUGUI timerLevelPro;
	public TextMeshProUGUI scorePro;
	public TextMeshProUGUI scorePro2;
	public TextMeshProUGUI timerGamePro;

	public string lastSceneLoaded;

	private void Start()
	{
		timerLevel = timerMax;
		lastSceneLoaded = SceneManager.GetActiveScene().name;
	}

	private void Update()
	{
		if (!_isGameOver)
		{
			timerGame = timerGame + Time.deltaTime;
			timerLevel = timerLevel - Time.deltaTime;
		}

		int minutosGame = (int)timerGame / 60;
		float segundosGame = timerGame % 60;

		timerLevelPro.text = timerLevel.ToString("f1");
		timerGamePro.text = string.Format("{0:00}:{1:00}", minutosGame, segundosGame);
		scorePro.text = score.ToString("f0");
		scorePro2.text = score.ToString("f0");

		if (timerLevel <= 0)
		{
			SceneManager.LoadScene("GameOver");
		}

		if (_isGameOver)
		{
			GameOverCOntador.SetActive(true);
			timerLevel = 0.01f;
		}
		else
		{
			GameOverCOntador.SetActive(false);
		}
	}

	public void NextLevel()
	{
		score = score + (timerLevel * multiplaller);

		timerLevel = timerMax;

		Debug.Log("Nex Level");
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
		if (lastSceneLoaded != scene.name)
		{
			NextLevel();
			lastSceneLoaded = scene.name;
		}

		if (scene.name == "GameOver")
		{
			_isGameOver = true;
		}
		else
		{
			_isGameOver = false;
		}

		if (scene.name == "Level 1")
		{
			score = 0;
			timerGame = 0;
		}
	}
}

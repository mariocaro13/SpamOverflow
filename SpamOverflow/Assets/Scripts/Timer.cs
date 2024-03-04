using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
	public float timer;

	public TextMeshProUGUI timerPro;

	private void Start()
	{
		timer = 3 * 60f;
	}

	private void Update()
	{
		timer = timer - Time.deltaTime;

		timerPro.text = timer.ToString("f1");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
	public float timer = 0;

	public TextMeshProUGUI timerPro;

	private void Update()
	{
		timer = timer + Time.deltaTime;

		timerPro.text = timer.ToString("f1");
	}
}

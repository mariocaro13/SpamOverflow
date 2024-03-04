using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool _canOpen;

    public string sceneName;

	public GameObject World;
	private Timer timerScript;

	private void Awake()
	{
		timerScript = World.GetComponent<Timer>();
	}

	void Update()
    {
        if (_canOpen && Input.GetKeyDown(KeyCode.W))
        {
			SceneManager.LoadScene(sceneName);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_canOpen = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_canOpen = false;
		}
	}
}

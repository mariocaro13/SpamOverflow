using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueBackgroundMusic : MonoBehaviour
{
	private static UniqueBackgroundMusic backgroundMusic;

	void Awake()
	{
		if(backgroundMusic == null)
		{
			backgroundMusic = this;
			DontDestroyOnLoad(this.gameObject);
		}

		else
		{
			Destroy(gameObject);
		}
	}
}

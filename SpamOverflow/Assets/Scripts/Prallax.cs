using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prallax : MonoBehaviour
{
	private float startpos;
	public GameObject play;
	public float parallaxEffect = 0;
	public float length = 0;

	void Start()
	{
		startpos = transform.position.x;
		//length = GetComponent<TilemapRenderer>().bounds.size.x;
	}

	void Update()
	{
		float temp = (play.transform.position.x * (1 - parallaxEffect));
		float dist = (play.transform.position.x * parallaxEffect);

		transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

		if (temp > startpos + length) startpos += length;
		else if (temp < startpos - length) startpos -= length;
	}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	private Rigidbody2D rb;
    public float speed;
	public bool _facingRight;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void   Start() {
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    	private void FixedUpdate()
	{
        Move();
	}

    private void Move() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    	private void Flip() {
		if (!_facingRight)
		{
            speed = speed * -1;
		}		
	}
}

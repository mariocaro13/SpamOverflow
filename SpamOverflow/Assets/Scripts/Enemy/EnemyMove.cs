using Unity.VisualScripting;
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

    	private void FixedUpdate()
	{
        Move();
	}

   private void    OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.SendMessageUpwards("ReSpawnOut");
    } 

    private void Move() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    	private void Flip() {
		if (!_facingRight)
            speed *= -1;
	}
}

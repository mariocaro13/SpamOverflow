using UnityEngine;

public class RespawnOut : MonoBehaviour
{
	[SerializeField] private GameObject containerSpamDead;
	private Rigidbody2D rb;

	public Transform startPoint;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void ReSpawnOut()
	{
		rb.velocity = Vector2.zero;
		containerSpamDead.SendMessageUpwards("SpawnSpamDeads");
		transform.position = startPoint.position;
	}  
}

using UnityEngine;

public class ColliderOut : MonoBehaviour
{
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			collision.SendMessageUpwards("ReSpawnOut");

		if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Cursor"))
            Destroy(collision.gameObject);
	}
}
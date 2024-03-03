using UnityEngine;

public class SpawnSpamDead : MonoBehaviour
{
    private BoxCollider2D spawnArea;
    public GameObject spamDeadPrefab;

    void Awake()
    {
        spawnArea = GetComponent<BoxCollider2D>();
    }
    
    public void SpawnSpamDeads()
    {
        float x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

        Instantiate(spamDeadPrefab, new Vector2(x, y), Quaternion.identity);
    }

}

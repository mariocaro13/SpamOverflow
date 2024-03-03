using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnRate;
    [SerializeField] private bool _facingRight;

    void Start()
    {
        SpawnEnemys();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            SpawnEnemys();
        }
    }

    private void SpawnEnemys() {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyMove enMove = enemy.GetComponent<EnemyMove>();
        enMove._facingRight = _facingRight;   
    }
}

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    GameObject enemy;

	public GameObject enemyPrefab;

    public bool _AmIEnemy;
    
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
        if (_facingRight && !_AmIEnemy)
        {
			 enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, -90));
		}
        else if (!_facingRight && !_AmIEnemy)
        {
			enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 90));
		}
        else if (_AmIEnemy)
        {
			enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
		}

        EnemyMove enMove = enemy.GetComponent<EnemyMove>();
        enMove._facingRight = _facingRight;   
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{	
    [SerializeField] private bool _amIProjectile;    
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnRate;
    [SerializeField] private bool _facingRight;
    
    public GameObject enemyPrefab;

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
        Quaternion rotation = Quaternion.identity;

        if (_amIProjectile)
            rotation = _facingRight ? Quaternion.Euler(0, 0, -90) : Quaternion.Euler(0, 0, 90);

        GameObject enemy = Instantiate(enemyPrefab, transform.position, rotation);
        if (enemy)
        {
            EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
            if (enemyMove)
                enemyMove._facingRight = _facingRight;   
        }
    }
}

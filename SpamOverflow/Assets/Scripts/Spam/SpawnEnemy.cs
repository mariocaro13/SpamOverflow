using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTimer;
    [SerializeField] private bool _facingRight;

    void Start()
    {
        SpawnEnemys();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 5f)
        {
            spawnTimer = 0;
            SpawnEnemys();
        }
    }

    private void SpawnEnemys(){

        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyMove enMove = enemy.GetComponent<EnemyMove>();
        enMove._facingRight = _facingRight;
        
    }
}

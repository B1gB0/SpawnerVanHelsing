using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private bool isWork = true;

    private void Start()
    {
        Initialize(_enemy.gameObject);
        StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private Vector3 GetRandomDirection()
    {
        int minNumber = 0;
        int maxNumber = 2;
        int number = Random.Range(minNumber, maxNumber);

        if (number == minNumber)
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.right;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while(isWork)
        {
            if (TryGetObject(out GameObject enemyPrefab))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemyPrefab, _spawnPoints[spawnPointNumber].position);

                EnemyMovement enemyMovement = enemyPrefab.GetComponent<EnemyMovement>();
                enemyMovement.SetDirection(GetRandomDirection());

                yield return waitForSeconds;
            }
        }
    }
}
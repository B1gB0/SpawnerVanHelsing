using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _delay;

    private float _elapsedTime = 0;
    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delay)
        {
            if(TryGetObject(out GameObject enemyPrefab))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemyPrefab, _spawnPoints[spawnPointNumber].position);
                Enemy enemy = enemyPrefab.GetComponent<Enemy>();
                enemy.Init(_player);
                enemy.Dying += OnEnemyDying;
            }
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}

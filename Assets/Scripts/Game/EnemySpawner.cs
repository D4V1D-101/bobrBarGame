using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
     private float _timeUntileSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntileSpawn -= Time.deltaTime;
        if (_timeUntileSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn() ;
        }
    }
    void SetTimeUntilSpawn()
    {
        _timeUntileSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}

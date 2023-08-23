using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float _timeUntilSpawn;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;
    [SerializeField] private GameObject _respawnField;
    [SerializeField] private GameObject _player;

    void Start()
    {

    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = Vector3.zero;

        for (int i = 0; i < 100; i++)
        {
            float distance = Random.Range(_minRadius, _maxRadius);
            Vector2 randomCirclePoint = Random.insideUnitCircle.normalized * distance;

            spawnPosition = new Vector3(randomCirclePoint.x, 1f, randomCirclePoint.y) + _player.transform.position;
            if (IsPositionValid(spawnPosition))
            {
                break;
            }
        }

        // Spawn the object at the determined position
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }

    bool IsPositionValid(Vector3 position)
    {
        float raycastDistance = 5f;
        RaycastHit hit;

        if (Physics.Raycast(position, Vector3.down, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("RespawnField"))
            {
                return true;
            }
        }

        return false;
    }

    void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    int RandomSign()
    {
        return Random.Range(0, 2) * 2 - 1;
    }
}

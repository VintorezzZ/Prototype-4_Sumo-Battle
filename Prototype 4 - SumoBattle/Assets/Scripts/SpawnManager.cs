using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private Vector3 spawnPos;
    private float spawnRange = 9f;

    public int enemyCount;
    public int waveNumber = 1;
    

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), Quaternion.identity);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), Quaternion.identity);
            SpawnEnemyWave(waveNumber);
        }

    }

    // Update is called once per frame

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesCount)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

}

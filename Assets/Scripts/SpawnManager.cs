using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRadius = 9;

    public int level = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        // start wave #1
        SpawnWave(level);
    }

    // Update is called once per frame
    void Update()
    {
        // if all enemies are destroyed, increase level and spawn new wave
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            level++;
            SpawnWave(level);
        }
    }

    void SpawnWave(int numberOfEnemies)
    {
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        for (int i = 0; i < numberOfEnemies; ++i)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);
        return new Vector3(randomX, 1, randomZ);
    }
}

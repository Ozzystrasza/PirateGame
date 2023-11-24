using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnSpots;
    [SerializeField] List<Ship> enemies;
    float spawnRate;

    public void StartSpawning(float spawnRate)
    {
        this.spawnRate = spawnRate;
        StartCoroutine(SpawnEnemies());
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Count);
        int spotIndex = Random.Range(0, spawnSpots.Count);

        Instantiate(enemies[enemyIndex], spawnSpots[spotIndex].position, spawnSpots[spotIndex].rotation);
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    float spawnPositionX = 17;

    [SerializeField] int maxSpawnTime, minSpawnTime;
    [SerializeField] GameObject[] enemies;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(0));   // Start immediately
        StartCoroutine(SpawnEnemy(180)); // after 3 mins
        StartCoroutine(SpawnEnemy(300)); // after 5 mins
        StartCoroutine(SpawnEnemy(600)); // after 10 mins
    }

    IEnumerator SpawnEnemy(float startDelay)
    {
        if(startDelay >= 0)
        {
            yield return new WaitForSeconds(startDelay);

            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

                float[] positions = { 0, 1.5f, 3f, 4.5f, 6f };

                float randomPositionY = positions[Random.Range(0, positions.Length)];
       
                Vector3 spawnPosition = new Vector2(spawnPositionX, randomPositionY);

                Instantiate(GetRandomEnemy(), spawnPosition, Quaternion.identity);
            }
        }

    }
    GameObject GetRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }
}

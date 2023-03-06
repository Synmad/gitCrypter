using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime;
    float minSpawnTime = 2f;
    float middleSpawnTime = 5f;
    float difficulty = 0.5f;

    public int enemyCount;

    public Transform[] spawnPoints;

    private void Awake()
    {
        spawnTime = 8.5f;
    }

    void Start()
    {
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        

        while (enemyCount < 6)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            enemyCount += 1;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void Update()
    {
        if (spawnTime > middleSpawnTime)
        {
            spawnTime -= difficulty * Time.deltaTime;
        }

        if (spawnTime <= middleSpawnTime && spawnTime > minSpawnTime)
        {
            spawnTime -= (difficulty / 10) * Time.deltaTime;
        }

    }
}

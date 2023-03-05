using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int xPosition;
    [SerializeField] int zPosition;
    [SerializeField] float spawnTime;
    float minSpawnTime = 0f;
    float middleSpawnTime = 4f;
    [SerializeField] float difficulty = 1f;

    public int enemyCount;

    [SerializeField] Transform[] spawnPoints;

    private void Awake()
    {
        spawnTime = 10;
    }

    void Start()
    {
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        

        while (enemyCount < 10)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            //xPosition = Random.Range(-17, 17);
            //zPosition = Random.Range(9, 19);
            //Instantiate(enemy, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            enemyCount += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        //if (spawnTime > middleSpawnTime)
        //{
        //    spawnTime -= difficulty;
        //    difficulty += 0.00001f * Time.deltaTime;
        //}

        //if (spawnTime < middleSpawnTime && spawnTime > minSpawnTime)
        //{
        //    spawnTime -= difficulty;
        //    difficulty += 0.000001f * Time.deltaTime;
        //}

    }
}

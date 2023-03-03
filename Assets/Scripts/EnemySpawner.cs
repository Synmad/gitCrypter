using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int xPosition;
    [SerializeField] int zPosition;
    public int enemyCount;


    void Start()
    {
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while (enemyCount < 8)
        {
            xPosition = Random.Range(-17, 17);
            zPosition = Random.Range(9, 19);
            Instantiate(enemy, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemyCount += 1;
        }
    }
        
    }

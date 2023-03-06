using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    GameObject gamemanager;
    EnemySpawner enemyspawner;

    private void Awake()
    {
        gamemanager = GameObject.Find("Game Manager");
        enemyspawner = gamemanager.GetComponent<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}

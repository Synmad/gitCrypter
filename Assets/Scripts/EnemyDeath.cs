using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] drops;
    [SerializeField] PlayerUI playerui;
    [SerializeField] EnemySpawner enemyspawner;
    [SerializeField] DamageFlash damageflash;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        playerui = canvas.GetComponent<PlayerUI>();

        GameObject gamemanager = GameObject.Find("Game Manager");
        enemyspawner = gamemanager.GetComponent<EnemySpawner>();

        damageflash = GetComponentInChildren<DamageFlash>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        damageflash.DamageFlashStart();

        if (health <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<EnemyChase>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            DropItem();
            playerui.ScoreUpdate(100);
            enemyspawner.enemyCount--;
            Destroy(gameObject, 6);
        }
    }

    

    void DropItem()
    {
        int randomIndex = Random.Range(0, drops.Length);
        Vector3 spawnPosition = new Vector3(transform.position.x, 0.8f, transform.position.z);

        Instantiate(drops[randomIndex], spawnPosition, Quaternion.identity);

        
    }
}
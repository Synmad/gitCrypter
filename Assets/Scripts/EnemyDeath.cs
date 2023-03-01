using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] drops;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<EnemyChase>().enabled = false;
            DropItem();
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }

    void DropItem()
    {
        int randomIndex = Random.Range(0, drops.Length);
        Vector3 spawnPosition = new Vector3(transform.position.x, 0.8f, transform.position.z);

        Instantiate(drops[randomIndex], spawnPosition, Quaternion.identity);

        
    }
}
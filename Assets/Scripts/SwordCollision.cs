using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public SwordController swordcontroller;
    public EnemyController enemycontroller;
    public GameObject enemy;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemycontroller = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && swordcontroller.isAttacking)
        {
            Debug.Log("Atacando a "+ other);
            enemycontroller.TakeDamage(1);
        }
        
    }
}

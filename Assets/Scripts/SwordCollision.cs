using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public SwordController swordcontroller;
    public EnemyController enemycontroller;
    public GameObject enemy;

    public int attackDamage = 1;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemycontroller = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && swordcontroller.isAttacking)
        {
            Debug.Log("Attacking: "+ other);
            enemycontroller.TakeDamage(attackDamage);
        }
        
    }
}

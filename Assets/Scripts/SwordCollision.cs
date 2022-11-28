using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public SwordController swordcontroller;
    public EnemyController enemycontroller;
    public GameObject enemy;
    bool canDamage = true;
    float damageCooldown = 1.0f;

    public int attackDamage = 1;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        enemycontroller = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && canDamage && swordcontroller.isAttacking)
        {
            Debug.Log("Attacking: " + other);
            enemycontroller.TakeDamage(attackDamage);
            canDamage = false;
            StartCoroutine(RefreshDamage());
        }
    }
    IEnumerator RefreshDamage()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}

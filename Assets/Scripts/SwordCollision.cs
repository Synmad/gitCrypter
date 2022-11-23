using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public SwordController swordcontroller;
    public EnemyController enemycontroller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && swordcontroller.isAttacking)
        {
            Debug.Log("El pepe");
            enemycontroller.TakeDamage(1);
        }
        
    }
}

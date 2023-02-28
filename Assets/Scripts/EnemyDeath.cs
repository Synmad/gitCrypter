using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Animator animator;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<EnemyChase>().enabled = false;
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }
}
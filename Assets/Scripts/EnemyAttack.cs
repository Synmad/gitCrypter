using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float range = 1f;
    public Transform attackPoint;
    public LayerMask playerLayer;

    public Animator animator;

    bool PlayerFound;

    public float damage = 1f;

    void Update()
    {
        PlayerFound = Physics.CheckSphere(attackPoint.position, range, playerLayer);

        if (PlayerFound)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }
}

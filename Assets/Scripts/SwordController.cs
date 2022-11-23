using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    [SerializeField] float attackCooldown = 1.0f;
    public bool isAttacking;
    bool canAttack = true;
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (canAttack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttack());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}

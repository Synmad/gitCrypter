using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] Player player;
    public SwordController swordcontroller;
    public EnemyDeath enemydeath;
    public GameObject enemy;
    bool canDamage = true;
    float damageCooldown = 1.0f;
    public Animator animator;

    public int attackDamage = 1;

    public bool attacking;

    private void Awake()
    {
        enemy = GameObject.FindWithTag("Enemy");
        //enemycontroller = enemy.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && canDamage && swordcontroller.isAttacking)
        {
            enemydeath = other.GetComponent<EnemyDeath>();
            Debug.Log("Attacking: " + other);
            hitSound.Play();
            enemydeath.TakeDamage(attackDamage);
            canDamage = false;
            StartCoroutine(RefreshDamage());
        }
    }
    IEnumerator RefreshDamage()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }

    private void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }
}

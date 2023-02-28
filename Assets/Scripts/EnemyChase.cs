using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyChase : MonoBehaviour
{
    [SerializeField] Animator animator;

    NavMeshAgent navmeshagent;
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosition;
    public float range = 1f;

    public Transform attackPoint;
    public LayerMask playerLayer;
    [SerializeField] bool playerNear;
    public float damage = 1f;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    private Vector3 distance = Vector3.zero;

    [SerializeField] float angle;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navmeshagent = GetComponent<NavMeshAgent>();

        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();
    }

    private void Start()
    {
        playerPosition = player.GetComponent<Transform>();
    }

    private void Update()
    {
       float distance = Vector3.Distance(playerPosition.position, transform.position);

       navmeshagent.destination = playerPosition.position;

       playerNear = distance <= 2f;

       
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
            {
            navmeshagent.destination = this.transform.position;
            navmeshagent.angularSpeed = 0f;
            navmeshagent.speed = 0f;
            navmeshagent.acceleration = 0f;
            }
         
        if (playerNear)
        {
            
            Vector3 playerDirection = playerPosition.position - transform.position;
            angle = Vector3.Angle(playerDirection, transform.forward * -1);

            if (angle >= 50.0f)
            {
                Attack();
            }

            else
            {
                animator.SetBool("isAttacking", false);
                navmeshagent.acceleration = 5f;
                navmeshagent.speed = 3f;
                navmeshagent.angularSpeed = 180f;
            }
            
            // else { rotateTowardsPlayer, aumentar velocidad rotación }

        }
        else
        {
            navmeshagent.isStopped = false;
            animator.SetBool("isAttacking", false);
            navmeshagent.acceleration = 5f;
            navmeshagent.speed = 3f;
            navmeshagent.angularSpeed = 180f;
        }
        //if (enemyfov.seeingPlayer)
        //{
        //    navmeshagent.SetDestination(player.transform.position);
        //    animator.SetBool("isChasing", true);
        //    navmeshagent.speed = 5.0f;
        //}
        //float distance = Vector3.Distance(player.transform.position, animator.transform.position);
        //if (distance < 3.5f && enemyfov.seeingPlayer)
        //    animator.SetBool("isAttacking", true);
        //if (enemyfov.seeingPlayer == false)
        //{
        //    animator.SetBool("isAttacking", false);
        //    animator.SetBool("isChasing", false);
        //}

    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }
}
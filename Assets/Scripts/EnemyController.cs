using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;

    [SerializeField] Animator animator;

    NavMeshAgent navmeshagent;
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosition;
    public float range = 1f;

    public Transform attackPoint;
    public LayerMask playerLayer;
    [SerializeField] bool playerFound;
    public float damage = 1f;

    public GameObject keyModel;

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

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //gameovercontroller.ShowGameOver("¡GANASTE!");
            //Time.timeScale = 0f;
            DropKey();
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }
    void DropKey()
    {
        GameObject key = Instantiate(keyModel, new Vector3 (transform.position.x, 0.8f, transform.position.z), Quaternion.identity);
    }

    private void Update()
    {
        //float producto = Vector3.Dot(playerPosition.position.normalized, transform.position.normalized);

       float distance = Vector3.Distance(playerPosition.position, transform.position);

       navmeshagent.destination = playerPosition.position;

       playerFound = distance <= 2f;

       
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
            {
            navmeshagent.destination = this.transform.position;
            navmeshagent.angularSpeed = 0f;
            navmeshagent.speed = 0f;
            navmeshagent.acceleration = 0f;
            }

            

        if (playerFound)
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
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

    Vector3 phase0 = new Vector3(10, 10, 10);

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navmeshagent = GetComponent<NavMeshAgent>();

        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();

        phase0 = transform.localScale;
    }

    private void Start()
    {
        playerPosition = player.GetComponent<Transform>();
    }

    private void Update()
    {
        UpdateChase();
    }

    //void UpdateGrow()
    //{        
    //    Vector3 phase1 = new Vector3(15, 15, 15);

    //    if (Vector3.Distance(phase0, phase1) >= -5)
    //    {
    //        transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime;
    //    }
    //}

    void UpdateChase()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);

        navmeshagent.destination = playerPosition.position;

        playerNear = distance <= 2f;

        if (navmeshagent.speed > 0f)
        {
            animator.SetBool("isChasing", true);
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AttackState") || (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")))
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

            if (angle >= 130.0f)
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
        }
        else
        {
            navmeshagent.isStopped = false;
            animator.SetBool("isAttacking", false);
            navmeshagent.acceleration = 5f;
            navmeshagent.speed = 3f;
            navmeshagent.angularSpeed = 180f;
        }
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }
}
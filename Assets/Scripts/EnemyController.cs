using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;

    [SerializeField] Animator animator;

    NavMeshAgent navmeshagent;
    public GameObject player;


    EnemyFOV enemyfov;

    public GameObject keyModel;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navmeshagent = GetComponent<NavMeshAgent>();

        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();

        enemyfov = GetComponent<EnemyFOV>();
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
        if (enemyfov.seeingPlayer)
        {
            navmeshagent.SetDestination(player.transform.position);
            animator.SetBool("isChasing", true);
            navmeshagent.speed = 5.0f;
        }
        float distance = Vector3.Distance(player.transform.position, animator.transform.position);
        if (distance > 3.5f)
            animator.SetBool("isAttacking", false);
        if (distance < 3.5f)
            animator.SetBool("isAttacking", true);
    }
}
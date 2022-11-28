using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;

    [SerializeField] Animator animator;

    EnemyFOV enemyfov;

    public GameObject keyModel;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    private void Awake()
    {
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
            animator.SetBool("isChasing", true);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Animator animator;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    private void Awake()
    {
        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            gameovercontroller.ShowGameOver("¡GANASTE!");
            Time.timeScale = 0f;
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Animator animator;

    public GameObject keyModel;

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
        Vector3 position = transform.position;
        GameObject key = Instantiate(keyModel, position, Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animation hingeanimation;

    public GameOverController gameovercontroller;
    public GameObject gameover;

    private void Awake()
    {
        gameover = GameObject.FindWithTag("Game Over");
        gameovercontroller = gameover.GetComponent<GameOverController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
            gameovercontroller.ShowGameOver("¡Ganaste!");
            Time.timeScale = 0f;
            //hingeanimation.Play();
    }
}

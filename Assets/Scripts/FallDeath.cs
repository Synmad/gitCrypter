using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    [SerializeField] GameOverController gameovercontroller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameovercontroller.GameOver();
        }
    }
}

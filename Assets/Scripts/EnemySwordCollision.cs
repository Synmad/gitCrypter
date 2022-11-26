using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordCollision : MonoBehaviour
{
    public Player playerscript;
    public GameObject player;

    public int attackDamage = 1;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerscript = player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Jugador recibe daño = "+attackDamage);
            playerscript.TakeDamage(attackDamage);
        }
    }
}

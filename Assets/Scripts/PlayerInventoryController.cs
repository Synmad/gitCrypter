using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerUI playerui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log("Agarrando item");
            other.gameObject.SetActive(false);

            if (other.name.Contains("Health"))
            {
                player.Heal(1);
            }

            if (other.name.Contains("Speed"))
            {
                player.movementSpeed += 1;
            }

            if (other.name.Contains("Points"))
            {
                Debug.Log("pija bolas");
                playerui.ScoreUpdate(100);
            }
        }
    }
}

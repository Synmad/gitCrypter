using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerUI playerui;
    [SerializeField] Light playerlight;

    [SerializeField] AudioSource healthSound;
    [SerializeField] AudioSource speedSound;
    [SerializeField] AudioSource pointsSound;

    private void OnTriggerEnter (Collider other)
    { 

        if (other.tag == "Item")
        {
            Debug.Log("Agarrando item");
            other.gameObject.SetActive(false);

            if (other.name.Contains("Health"))
            {
                player.Heal(1);
                healthSound.Play();
            }

            if (other.name.Contains("Speed"))
            {
                speedSound.Play();
                player.speedMultiplier += 0.8f;
            }

            if (other.name.Contains("Points"))
            {
                pointsSound.Play();
                playerui.ScoreUpdate(100);
                playerlight.range += 1;
            }
        }
    }
}

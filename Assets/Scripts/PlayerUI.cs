using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI healthText;

    private void Awake()
    {
        
    }

    void Update()
    {
        healthText.text = player.curHealth.ToString() + " HP";
    }
}

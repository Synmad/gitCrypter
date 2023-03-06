using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] Player player;
    public TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] SwordCollision swordcollision;

    public int score = 0;

    private void Awake()
    {
        scoreText.text = "0";
        healthText.text = player.curHealth.ToString() + " HP";
    }

    public void ScoreUpdate(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = score.ToString();

        if (score == 1000)
        {
            swordcollision.attackDamage++;
        }

        if (score == 2000)
        {
            swordcollision.attackDamage++;
        }
    }

    public void HealthUpdate()
    {
        healthText.text = player.curHealth.ToString() + " HP";
    }
}

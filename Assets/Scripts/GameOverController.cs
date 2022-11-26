using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text gameovertext;
    Player playerscript;
    public GameObject player;
    public GameObject gameoverpanel;

    public void Awake()
    {
        gameovertext = gameoverpanel.GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        playerscript = player.GetComponent<Player>();
    }
    public void ShowGameOver (string victoryOrDefeat)
    {
        gameovertext.gameObject.SetActive(true);
        gameovertext.text = victoryOrDefeat;
    }
}

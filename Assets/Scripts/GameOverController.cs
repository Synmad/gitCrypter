using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        gameoverpanel.gameObject.SetActive(true);
        gameovertext.text = victoryOrDefeat;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

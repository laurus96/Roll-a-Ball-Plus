using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject spawner;
    public GameObject gameOverPanel;
    public GameObject saveScorePanel;
    public GameObject warningWall;
    public GameObject scoreText;

    public InputField playerNameInput;


    public Text bestScore;
    public Text gameOverText;

    public Camera mainCamera;

    private bool gameOverMenu = true;

    private void Start()
    {
        //playerNameInput.onEndEdit.AddListener(delegate { SaveScore(); });
    }

    private void LateUpdate()
    {
        if (CollectCoin.score <= 0)
        {
            player.SetActive(false);
            spawner.SetActive(false);
            scoreText.SetActive(false);

            mainCamera.transform.position= new Vector3(0f, 7f, -7f);

            if (gameOverMenu)
            {
                gameOverPanel.SetActive(true);
                warningWall.SetActive(false);
            }

            bestScore.text = "Your Score is: " + CollectCoin.bestScore;
            
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void activateSaveMenu()
    {
        gameOverMenu = false;

        gameOverPanel.SetActive(false);
        saveScorePanel.SetActive(true);
    }

    public void SaveScore()
    {
        Player p = new Player(playerNameInput.text, CollectCoin.bestScore);
        LeaderboardLogic.addPlayerToLeaderboard(p);
        LeaderboardLogic.SaveFile();

        saveScorePanel.SetActive(false);
        gameOverMenu = true;


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject helpPanel;

    public Button start;
    public Button leaderboard;
    public Button help;
    public Button exit;


    private void Awake()
    {
        leaderboardPanel.SetActive(false);
        helpPanel.SetActive(false);

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LeaderboardDisplay()
    {
        leaderboardPanel.SetActive(true);
        start.interactable = false;
        leaderboard.interactable = false;
        help.interactable = false;
        exit.interactable = false;


    }

    public void HelpDisplay()
    {
        helpPanel.SetActive(true);
        start.interactable = false;
        leaderboard.interactable = false;
        help.interactable = false;
        exit.interactable = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        if (leaderboardPanel.activeSelf)
        {
            leaderboardPanel.SetActive(false);
            start.interactable = true;
            leaderboard.interactable = true;
            help.interactable = true;
            exit.interactable = true;
        }

        else if (helpPanel.activeSelf)
        {
            helpPanel.SetActive(false);
            start.interactable = true;
            leaderboard.interactable = true;
            help.interactable = true;
            exit.interactable = true;
        }
    }
}

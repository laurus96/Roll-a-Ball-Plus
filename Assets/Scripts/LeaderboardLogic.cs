using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardLogic : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject errorLeaderboard;

    public Text playerName;
    public Text playerScore;

    
    private static SortedList<int, string> playersLeaderboard = new SortedList<int, string>();
    private static bool error = false;
    private static GameObject leaderboardPanelStatic;
    private static Text playerNameStatic;
    private static Text playerScoreStatic;

    private bool loaded = false;

    private void Start()
    {
        playerNameStatic = playerName;
        playerScoreStatic = playerScore;
        leaderboardPanelStatic = leaderboardPanel;

    }
    private void LateUpdate()
    {
        if (leaderboardPanel.activeSelf && !loaded)
        {
            LoadFile();
            loaded = true;
        }

        if (error)
        {
            errorLeaderboard.SetActive(true);
        }
    }

    public static void addPlayerToLeaderboard(Player p)
    {
        playersLeaderboard.Add(p.PlayerScore, p.PlayerName);
    }

    public static void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, playersLeaderboard);
        file.Close();
    }

    public static void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            error = true;
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        playersLeaderboard = (SortedList<int, string>)bf.Deserialize(file);
        
        IList<int> iScores = playersLeaderboard.Keys;
        List<int> scores = new List<int>();

        foreach(int i in iScores)
        {
            scores.Add(i);
        }

        scores.Sort();
        scores.Reverse();

        Vector3 preName = playerNameStatic.transform.position;
        Vector3 preScore = playerScoreStatic.transform.position;

        foreach (int i in scores)
        {
            Vector3 newPosName = new Vector3(preName.x, preName.y, preName.z);
            Vector3 newPosScore = new Vector3(preScore.x, preScore.y, preScore.z);

            Text name = Instantiate(playerNameStatic, newPosName, Quaternion.identity) as Text;
            Text score = Instantiate(playerScoreStatic, newPosScore, Quaternion.identity) as Text;

            name.text = playersLeaderboard[i];
            score.text = "" + i;

            name.transform.SetParent(leaderboardPanelStatic.transform, false);
            score.transform.SetParent(leaderboardPanelStatic.transform, false);


            newPosName.y += -20;
            newPosScore.y += -20;

            preName = newPosName;
            preScore = newPosScore;
        }

        file.Close();


        
    }


}


[System.Serializable]
public class Player
{
    
    private string playerName;
    private int playerScore;

    public Player(string name, int score)
    {
        playerName = name;
        playerScore = score;
    }

    public int PlayerScore { get => playerScore; set => playerScore = value; }
    public string PlayerName { get => playerName; set => playerName = value; }


}

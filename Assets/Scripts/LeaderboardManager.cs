using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Text playerScoreText;
    public Text highScoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            int playerScore = PlayerPrefs.GetInt("PlayerScore");
            playerScoreText.text = playerScore.ToString();
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = highScore.ToString();
        }
    }
}


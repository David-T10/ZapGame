using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Text scoreCounterText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            scoreCounterText.text = PlayerPrefs.GetInt("PlayerScore").ToString();
        }
        else
        {
            ResetScore();
        }
    }

    public void ResetScore()
    {
        int nilScore = 0;
        UpdateScoreOnUI(nilScore);
        PlayerPrefs.SetInt("PlayerScore", nilScore); 
        PlayerPrefs.Save();
    }

    public void IncrementScore(int score)
    {
        int currScore = PlayerPrefs.GetInt("PlayerScore");
        int newScore = currScore + score;
        UpdateScoreOnUI(newScore);
    }

    public void UpdateScoreOnUI(int score)
    {
        scoreCounterText.text = score.ToString();
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    public int GetPlayerScore()
    {
        return PlayerPrefs.GetInt("PlayerScore", 0);
    }

    public void SaveHighScore()
    {
        int currentScore = GetPlayerScore();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }
}

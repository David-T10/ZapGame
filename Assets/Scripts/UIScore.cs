using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Text scoreCounterText;

    public void ResetScore()
    {
        int nilScore = 0;
        UpdateScoreOnUI(nilScore);
    }

    public void IncrementScore(int score)
    {
        int currScore = Convert.ToInt32(scoreCounterText.text);
        int newScore = currScore + score;
        UpdateScoreOnUI(newScore);
    }

    public void UpdateScoreOnUI(int score)
    {
        GameData.playerScore -= int.Parse(scoreCounterText.text);
        scoreCounterText.text = score.ToString();
        GameData.playerScore += score;
    }

    public void Start() 
    {
        scoreCounterText.text = GameData.playerScore.ToString();
    }
}

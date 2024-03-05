using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private const string SCORE_KEY = "PlayerScore";
    private int score = 0;
    [SerializeField] private Text scoreCounterText;

    private void Start() 
    {
        LoadScore();
        UpdateScoreOnScreen();
    }

    public void IncrementScore(int points) 
    {
        score += points;
        SaveScore();
        UpdateScoreOnScreen();
    }

    public void ResetScore() 
    {
        score = 0;
        SaveScore();
        UpdateScoreOnScreen();
    }

    public void SaveScore() 
    {
        PlayerPrefs.SetInt(SCORE_KEY, score);
    }

    public void LoadScore() 
    {
        score = PlayerPrefs.GetInt(SCORE_KEY, 0);
    }

    private void OnDisable() 
    {
        SaveScore();
    }

    private void OnEnable() 
    {
        LoadScore();
    }

    public void UpdateScoreOnScreen() 
    {
        scoreCounterText.text = "Score: " + score.ToString();
    }
}

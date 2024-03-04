using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string SCORE_KEY = "PlayerScore";
    private int score = 0;

    private void Start() 
    {
        LoadScore();
    }

    public void IncrementScore(int points) 
    {
        score += points;
        SaveScore();
    }

    public void ResetScore() 
    {
        score = 0;
        SaveScore();
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
}

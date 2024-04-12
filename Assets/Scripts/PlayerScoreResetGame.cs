using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreResetGame : MonoBehaviour
{
    private void Awake()
    {
        ResetPlayerScore();
    }

    private void ResetPlayerScore()
    {
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.Save();
    }
}

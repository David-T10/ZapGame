using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBtn : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("Level 1");
    }

    public void StartTutorial() 
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void ShowLeaderboard() 
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ShowCredits() 
    {
        SceneManager.LoadScene("End Screen");
    }
}

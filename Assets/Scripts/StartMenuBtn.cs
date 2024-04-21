using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBtn : MonoBehaviour
{
    [SerializeField] private AudioSource mainMenuMusic; 

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

    public void ToggleMute()
    {
        if(mainMenuMusic != null)
        {
            mainMenuMusic.volume = mainMenuMusic.volume > 0 ? 0 : 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool finishedLevel = false;
    private UIScore uiScore;
    private int completeLevelScore = 10;

    private void Start()
    {
        uiScore = GameObject.FindObjectOfType<UIScore>();
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerObject" && !finishedLevel)
        {
            finishSoundEffect.Play();
            finishedLevel = true;
            uiScore.IncrementScore(completeLevelScore);
            Invoke("CompleteGame", 2f);
        }
    }

    private void CompleteGame()
    {
        uiScore.SaveHighScore();
        SceneManager.LoadScene("Leaderboard");
    }
}
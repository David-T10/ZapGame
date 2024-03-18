using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTutorial : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool finishedTutorial = false;
    private UIScore uiScore;
    private int completeLevelScore = 10;

    private void Start()
    {
        uiScore = GameObject.FindObjectOfType<UIScore>();
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerObject" && !finishedTutorial)
        {
            finishSoundEffect.Play();
            finishedTutorial = true;
            uiScore.IncrementScore(completeLevelScore);
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        uiScore.ResetScore();
        SceneManager.LoadScene("Level 1");
    }
}
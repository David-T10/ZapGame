using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishlevel : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool finishedLevel = false;
    private ScoreManager scoreManager;
    private int completeLevelScore = 10;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerObject" && !finishedLevel)
        {
            finishSoundEffect.Play();
            finishedLevel = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        scoreManager.IncrementScore(completeLevelScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
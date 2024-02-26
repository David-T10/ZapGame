using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishlevel : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerObject")
        {
            finishSoundEffect.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {

    }
}
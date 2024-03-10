using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int playerHealth = 6;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts) 
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < playerHealth; i++)
        {
                hearts[i].sprite = fullHeart;
        }

    }

    public void ResetHealth() 
    {
        playerHealth = 6;
    }

    public void DecrementHealth(int damageTaken) 
    {
        playerHealth -= damageTaken;
    }
}

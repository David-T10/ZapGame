using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;  
    [SerializeField] private AudioSource backgroundMusic;  
    private bool isMuted = false;         

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        backgroundMusic.mute = isMuted;  
    }

    public void ToggleMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();  
        }
        else
        {
            backgroundMusic.Play();  
        }
    }
}

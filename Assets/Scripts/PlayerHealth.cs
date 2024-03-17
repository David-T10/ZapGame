using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerAnimationManager playerAnimationManager;
    private Rigidbody2D rb2d;
    private UIScore uiScore;
    private UIHealth uiHealth;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;

    private float spikeTrapDamage = -20f;
    private float fireTrapDamage = -30f;
    private float fallDamage = -100f;

    private void Awake()
    {
        uiScore = GameObject.FindObjectOfType<UIScore>();
        uiHealth = GameObject.FindObjectOfType<UIHealth>();
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimationManager = GetComponent<PlayerAnimationManager>();
    }

    public void Start() 
    {
        respawnPoint = transform.position;
    }

    public void Update() 
    {
        fallDetector.transform.position = new Vector2(transform.position.x,fallDetector.transform.position.y);
        playerAnimationManager.UpdateAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("SpikeTrap"))
        {
            uiHealth.UpdateHeath(spikeTrapDamage);
            if (uiHealth.GetCurrentHealth() <= 0)
            {
                Death();
            }
        }
        else if (collision.gameObject.CompareTag("FireTrap")) 
        {
            uiHealth.UpdateHeath(fireTrapDamage);
            if(uiHealth.GetCurrentHealth() <= 0) 
            {
                Death();
            }
        }
        else if (collision.gameObject.CompareTag("FallDetector"))
        {
            uiHealth.UpdateHeath(fallDamage);
            Death();
        } 
    }

    private void Death() {
        deathSoundEffect.Play();
        playerAnimationManager.DeathAnimation();
        uiScore.ResetScore();
    }

    private void Regenerate() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

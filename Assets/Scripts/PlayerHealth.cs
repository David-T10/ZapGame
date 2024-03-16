using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerAnimationManager playerAnimationManager;
    private Rigidbody2D rb2d;
    private UIScore uiScore;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource damageSoundEffect;

    private int spikeTrapDamage = 1;
    private int fireTrapDamage = 2;

    private void Awake()
    {
        uiScore = GameObject.FindObjectOfType<UIScore>();
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
            Death();
        }
        else if (collision.gameObject.CompareTag("FireTrap")) 
        {
            Death();
        }
        else if (collision.gameObject.CompareTag("FallDetector"))
        {
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

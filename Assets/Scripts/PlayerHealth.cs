using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerAnimationManager playerAnimationManager;
    private Rigidbody2D rb2d;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
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
        if (collision.gameObject.CompareTag("InstantKillTrap"))
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
    }

    private void Regenerate() { 
        //transform.position = respawnPoint;
        //playerAnimationManager.Upda
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

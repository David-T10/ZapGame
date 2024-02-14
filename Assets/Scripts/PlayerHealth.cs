using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("InstantKillTrap")) {
            Death();
        } 
    }

    private void Death() {
        rb2d.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void Regenerate() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

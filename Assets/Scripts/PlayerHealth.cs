using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("InstantKillTrap")) {
            Death();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Death() {
        rb2d.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }
}

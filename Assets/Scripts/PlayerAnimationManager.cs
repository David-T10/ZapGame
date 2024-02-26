using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private enum Movements
    {
        idle, running, jumping, falling
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void UpdateAnimation() 
    {
        Movements movementState;
        if (rb2d.velocity.x > 0f)
        { //moving right
            spriteRenderer.flipX = false;
            movementState = Movements.running;
        }
        else if (rb2d.velocity.x < 0f)
        { //moving left
            spriteRenderer.flipX = true;
            movementState = Movements.running;
        }
        else
        {
            movementState = Movements.idle;
        }

        if (rb2d.velocity.y > .1f)
        {
            movementState = Movements.jumping;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            movementState = Movements.falling;
        }

        animator.SetInteger("movementState", (int)movementState);
    }
}

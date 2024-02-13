using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float xVal;

    [SerializeField] private float jumpValue = 7f;
    [SerializeField] private float movementSpeed = 7f;

    private enum Movements{
        idle, running, jumping, falling
    }
    private void Awake()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();  
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpValue);
        }

        xVal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVal * movementSpeed, rb.velocity.y);

        PlayerAnimationController();
    }

    private void PlayerAnimationController(){

        Movements movementState;
        if (rb.velocity.x > 0f ){ //moving right
            spriteRenderer.flipX = false;
            movementState = Movements.running;
        } else if (rb.velocity.x < 0f){ //moving left
            spriteRenderer.flipX = true;
            movementState = Movements.running;
        }else {
            movementState = Movements.idle;
        }

        if(rb.velocity.y > .1f){
            movementState = Movements.jumping;
        } else if (rb.velocity.y < -.1f){
            movementState =Movements.falling;
        }

        animator.SetInteger("movementState", (int)movementState);
    }
}

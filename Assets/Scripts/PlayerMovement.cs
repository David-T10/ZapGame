using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity = Vector2.zero;

    private Rigidbody2D rb2d;
    private BoxCollider2D coll2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float xVal;

    [SerializeField] private float jumpValue = 5f;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;

    private enum Movements{
        idle, running, jumping, falling
    }
    private void Awake()
    {
      rb2d = GetComponent<Rigidbody2D>();
      coll2d = GetComponent<BoxCollider2D>();  
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    private void Start()
    {
        rb2d.velocity = initialVelocity;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpValue);
        }

        xVal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(xVal * movementSpeed, rb2d.velocity.y);

        UpdatePlayerAnimation();
    }

    private void UpdatePlayerAnimation(){

        Movements movementState;
        if (rb2d.velocity.x > 0f ){ //moving right
            spriteRenderer.flipX = false;
            movementState = Movements.running;
        } else if (rb2d.velocity.x < 0f){ //moving left
            spriteRenderer.flipX = true;
            movementState = Movements.running;
        }else {
            movementState = Movements.idle;
        }

        if(rb2d.velocity.y > .1f){
            movementState = Movements.jumping;
        } else if (rb2d.velocity.y < -.1f){
            movementState =Movements.falling;
        }

        animator.SetInteger("movementState", (int)movementState);
    }

    private bool OnGround(){
        return Physics2D.BoxCast(coll2d.bounds.center, coll2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public float GetJumpValue() {
        return jumpValue;
    }

    public void SetJumpValue(float newVal) {
        jumpValue = newVal;
    }

    public float GetMovementSpeedValue()
    {
        return movementSpeed;
    }

    public void SetMovementSpeedValue(float newVal)
    {
        movementSpeed = newVal;
    }
}

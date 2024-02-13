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

    [SerializeField] private float jumpValue = 5f;
    [SerializeField] private float movementSpeed = 7f;
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

        if (xVal > 0f ){ //moving right
            spriteRenderer.flipX = false;
            animator.SetBool("running",true);
        } else if (xVal < 0f){ //moving left
            spriteRenderer.flipX = true;
            animator.SetBool("running",true);
        }else {
            animator.SetBool("running",false);
        }
    }
}

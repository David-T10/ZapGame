using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D coll2d;
    private Command jumpCmd;
    private PlayerAnimationManager playerAnimationManager;
    private float xInputVal;

    [SerializeField] private float jumpValue = 5f;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;

    public float GetJumpValue()
    {
        return jumpValue;
    }

    public void SetJumpValue(float newVal)
    {
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

    public void UpdateJumpCommand(float newJumpValue) 
    {
        jumpCmd = new JumpCommand(rb2d, newJumpValue);
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<BoxCollider2D>();
        jumpCmd = new JumpCommand(rb2d, GetJumpValue());
        playerAnimationManager = GetComponent<PlayerAnimationManager>();

    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            jumpCmd.Execute();
        }

        xInputVal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(xInputVal * GetMovementSpeedValue(), rb2d.velocity.y);
        rb2d.velocity = new Vector2(xInputVal * GetMovementSpeedValue(), rb2d.velocity.y);

        playerAnimationManager.UpdateAnimation();
        
    }

    private bool OnGround()
    {
        return Physics2D.BoxCast(coll2d.bounds.center, coll2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

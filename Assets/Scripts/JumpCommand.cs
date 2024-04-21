using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    private Rigidbody2D rb2d;
    private float jumpForce;

    public JumpCommand(Rigidbody2D playerRb, float playerJumpForce) 
    {
        this.rb2d = playerRb;
        this.jumpForce = playerJumpForce;
    }

    
    public void Execute()
    {
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
    }
}

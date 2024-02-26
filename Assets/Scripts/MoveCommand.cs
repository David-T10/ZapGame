using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Rigidbody2D rb2d;
    private float movementSpeed;


    public MoveCommand(Rigidbody2D playerRb, float playerSpeed)
    {
        this.rb2d = playerRb;
        this.movementSpeed = playerSpeed;
    }


    // Update is called once per frame
    public void Execute()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * movementSpeed, rb2d.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : EnemyState
{
    public ChasingState(EnemyMovement enemy) : base(enemy) { }

    public override void UpdateState()
    {
        if (!enemy.PlayerInRange())
        {
            enemy.TransitionToState(new PatrollingState(enemy));
        }
        else
        {
            Vector2 direction = (enemy.playerPosition.position - enemy.transform.position).normalized;
            enemy.Move(direction);
            enemy.FlipSprite(direction.x);
        }
    }

    public override void OnJumpCooldownEnd()
    {
        if (enemy.OnGround() && enemy.canJump)
        {
            enemy.Jump();
            enemy.canJump = false;
            enemy.StartCoroutine(enemy.StartJumpCooldown());
        }
    }
}

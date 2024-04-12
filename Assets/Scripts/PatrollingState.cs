using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : EnemyState
{
    public PatrollingState(EnemyMovement enemy) : base(enemy) { }

    public override void UpdateState()
    {
        if (enemy.PlayerInRange())
        {
            enemy.TransitionToState(new ChasingState(enemy));
        }
        else
        {
            if (enemy.patrolDestination == 0)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.patrolPoints[0].position, enemy.moveSpeed * Time.deltaTime);
                if (Vector2.Distance(enemy.transform.position, enemy.patrolPoints[0].position) < .2f)
                {
                    enemy.transform.localScale = new Vector3(1, 1, 1);
                    enemy.patrolDestination = 1;
                }
            }
            if (enemy.patrolDestination == 1)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.patrolPoints[1].position, enemy.moveSpeed * Time.deltaTime);
                if (Vector2.Distance(enemy.transform.position, enemy.patrolPoints[1].position) < .2f)
                {
                    enemy.transform.localScale = new Vector3(-1, 1, 1);
                    enemy.patrolDestination = 0;
                }
            }
        }
    }
}

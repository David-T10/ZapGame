using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyMovement enemy;

    public EnemyState(EnemyMovement enemy)
    {
        this.enemy = enemy;
    }

    public abstract void UpdateState();
    public virtual void OnJumpCooldownEnd() { }
}

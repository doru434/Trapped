using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : EnemyState
{
    public FightState(Enemy enemy) : base(enemy)
    {
        Debug.Log("fightstate");
    }

    public override void StateTick()
    {
        throw new System.NotImplementedException();
    }

    public override EnemyState UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

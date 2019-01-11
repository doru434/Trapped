using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private float idleTime;

    public IdleState(Enemy enemy) : base(enemy)
    {
        idleTime = 5.0f;
        Debug.Log("IdleState");
    }

    public override void StateTick()
    {
        idleTime -= Time.deltaTime;
    }

    public override EnemyState UpdateState()
    {

        //Logic to ChasingState
        if(enemy.Disttoplayer() < 10.0f)
        return new ChasingState(enemy);
        //Logic to FightState
        if(enemy.Disttoplayer() < 1.0f)
        return new FightState(enemy);
        //Logic to PatrolState
        if(idleTime <= 0.0f)
        return new PatrolState(enemy);
        
    
        return this;
    }
}


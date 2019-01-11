using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : EnemyState
{
    public ChasingState(Enemy enemy) : base(enemy)
    {
        Debug.Log("chesingState");
    }

    public override void StateTick()
    {
        //DO zmiany
        enemy.NavMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    public override EnemyState UpdateState()
    {
        //Logic to IdleState
        if (enemy.Disttoplayer() > 11.0f)
            return new IdleState(enemy);

        return this;
    }
}

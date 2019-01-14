using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : EnemyState {

    Vector3 closestPoint;

    public PatrolState(Enemy enemy) : base(enemy)
    {
        closestPoint = FindClosestPatrolPoint();
        enemy.NavMeshAgent.SetDestination(closestPoint);
        enemy.NavMeshAgent.Move(new Vector3(0, 0, 0));

    }

    public override void StateTick()
    {
        if (enemy.NavMeshAgent.remainingDistance <= 1)
        {
            closestPoint = FindClosestPatrolPoint();
            enemy.NavMeshAgent.SetDestination(closestPoint);
            enemy.NavMeshAgent.Move(new Vector3(0, 0, 0));
        }
        animationvalue = 1;
    }

    public override EnemyState UpdateState()
    {
        //Logic to ChasingState
        if (enemy.Disttoplayer() < 10.0f)
            return new ChasingState(enemy);
        //Logic to FightState
        if (enemy.Disttoplayer() < 1.0f)
            return new FightState(enemy);

        return this;
    }

    private Vector3 FindClosestPatrolPoint()
    {
        //PatrolpointList bedzie ogólnodostępne z zewnetrznej klasy
        GameObject[] PatrolPointList = GameObject.FindGameObjectsWithTag("PatrolPoint");
        Vector3 temporaryPoint = new Vector3(999.0f, 999.0f, 999.0f);
        foreach (GameObject point in PatrolPointList)
        {
            if ((enemy.transform.position + enemy.transform.forward - temporaryPoint).magnitude > (enemy.transform.position + enemy.transform.forward - point.transform.position).magnitude)
                if (point.transform.position != closestPoint)
                temporaryPoint = point.transform.position;
        }
        return temporaryPoint;
    }

}

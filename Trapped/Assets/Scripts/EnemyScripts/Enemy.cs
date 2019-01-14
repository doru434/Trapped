using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int HitPoints = 20;
    public int PhisicalDmg = 5;
    public int PhisicalDef = 2;
    public float AtackSpeed = 2.5f;

    public EnemyState currentState;
    public NavMeshAgent NavMeshAgent;

    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        currentState = new IdleState(this);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        currentState.StateTick();
        currentState = currentState.UpdateState();
        animator.SetInteger("AnimationParameter", currentState.animationvalue);
    }

    public void OnHit()
    {
        HitPoints -= 5;
    }

    public void Atack()
    {

    }

    private void OnMouseDown()
    {
        OnHit();
    }
    public float Disttoplayer()
    {
        return (transform.position - player.transform.position).magnitude;
    }

}

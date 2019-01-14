using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState {
    protected Enemy enemy;
    public int animationvalue = 0;

    public EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    
    abstract public EnemyState UpdateState();
    abstract public void StateTick();

}

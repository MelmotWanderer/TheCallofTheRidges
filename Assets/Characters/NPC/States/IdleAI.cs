using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAI : State
{

    private AttackAIController _switcher;
    private int _countPointPatrol;
    private Sun _sun;
    
    public IdleAI(AttackAIController switcher, int countPointPatrol, Sun sun)
    {
        _switcher = switcher;
        _countPointPatrol = countPointPatrol;
        _sun = sun;
    }

   


    public override void Run()
    {
        if (_countPointPatrol > 0)
        {
            
            _switcher.SwitchMoveState<SearchTargetMove>();

        }
        if (_sun.EnemyAttack && _switcher.IsActiveEnemy)
        {
            _switcher.SwitchMoveState<AttackAI>();
        }

        
      
    }




}

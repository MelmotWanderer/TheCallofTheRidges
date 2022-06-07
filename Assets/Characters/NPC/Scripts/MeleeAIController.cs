using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAIController : AttackAIController
{



    protected override void InitEnemy()
    {
        _states.Add(new RunningAI(this, _navMesh, _animator, _attackMeleeDistance));
        _states.Add(new AttackAI(this, _animator, _collisionWeapon, _attackMeleeDistance));
    }



    public void EnableColliderWeapon()
    {
        _collisionWeapon.GetComponent<Collider>().enabled = true;

    }
    public void DisableColliderWeapon()
    {
        _collisionWeapon.GetComponent<Collider>().enabled = false;

    }




    public override void StartAttack()
    {
        SwitchMoveState<RunningAI>();
    }
}

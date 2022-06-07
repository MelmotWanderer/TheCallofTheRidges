using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAI : State
{
    private AttackAIController _controller;
    private Animator _animator;
    private CollisionWeapon _collisionWeapon;
    private float _attackMeleeDistance;
    public AttackAI(AttackAIController controller, Animator animator, CollisionWeapon collisionWeapon, float attackMeleeDistance)
    {
        _controller = controller;

        _animator = animator;

        _collisionWeapon = collisionWeapon;
        _attackMeleeDistance = attackMeleeDistance;
    }

 
    public override void Run()
    {
       if (!_controller.isPlayerAlive())
        {
            _controller.SwitchMoveState<SearchTargetMove>();
        }

        _animator.SetTrigger("Attack");

 
      

       if (Vector3.Distance(_controller.transform.position, _controller.GetPlayerTransform().position) > _attackMeleeDistance)
            {
                _controller.SwitchMoveState<RunningAI>();
       
            }
   
        
    }
    public override void Stop()
    {

        _collisionWeapon.GetComponent<Collider>().enabled = false;
    }

 
}

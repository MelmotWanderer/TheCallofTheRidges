using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RunningAI : State
{

    private AttackAIController _controller;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    private float _attackMeleeDistance;

    public RunningAI(AttackAIController controller, NavMeshAgent navMesh, Animator animator, float attackMeleeDistance)
    {
        _controller = controller;
        _navMesh = navMesh;
        _animator = animator;
        _attackMeleeDistance = attackMeleeDistance;
    }
    public override void StartState()
    {
        _animator.SetBool("Run", true);
        _navMesh.SetDestination(_controller.GetPlayerTransform().position);
    }

    public override void Run()
    {

        if (Vector3.Distance(_controller.transform.position, _controller.GetPlayerTransform().position) < _attackMeleeDistance)
        {
            _controller.SwitchMoveState<AttackAI>();
        }
        else
        {
            _controller.SwitchMoveState<RunningAI>();
            
        }
    }

    public override void Stop()
    {

        _animator.SetBool("Run", false);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WalkAI : State
{

    private NavMeshAgent _navMesh;
    private List<Transform> _patrolPoint;
    private Animator _animator;
    private AttackAIController _controller;
    public WalkAI(AttackAIController controller, NavMeshAgent navMesh, List<Transform> patrolPoint, Animator animator)
    {
        _controller = controller;
        _navMesh = navMesh;
        _patrolPoint = patrolPoint;
        _animator = animator;

    }

    
    public override void StartState()
    {
        _animator.SetBool("Walk", true);
        _navMesh.SetDestination(_controller.currentTargetMove);
    }


    public override void Run()
    {
        
        

        if (Vector3.Distance(_controller.transform.position, _controller.currentTargetMove) < 0.1f)
        {
  
            _controller.SwitchMoveState<SearchTargetMove>();

        }
    }

    public override void Stop()
    {
        _animator.SetBool("Walk", false);
        
    }
}

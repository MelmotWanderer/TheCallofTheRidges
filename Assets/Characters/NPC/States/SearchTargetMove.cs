using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTargetMove : State
{
    private AttackAIController _controller;
    private List<Transform> _patrolPoint;
    private float time;
    private float currentTime;


    public SearchTargetMove(AttackAIController controller, List<Transform> patrolPoint)
    {
        _controller = controller;
        _patrolPoint = patrolPoint;
    }
    public override void StartState()
    {
        time = 2.0f;
        currentTime = 2.0f;
    }
    public override void Run()
    {

        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            if (_patrolPoint.Count - 1 == _controller.indexCurrenWayPoint)
            {
                _controller.ChangeIndexCurrentPatrolPoint(0);
            }
            else
            {
                _controller.ChangeIndexCurrentPatrolPoint(_controller.indexCurrenWayPoint + 1);
            }
            _controller.SetTarget(_patrolPoint[_controller.indexCurrenWayPoint].position);
            _controller.SwitchMoveState<WalkAI>();
            currentTime = time;
        }
    }
}


using UnityEngine;

public class Walk : State
{

    private Animator _animator;
    private PlayerController _controller;
    private float _speed;
 
    public Walk(PlayerController controller, float speed, Animator animator)
    {
        _controller = controller;
        _animator = animator;
        _speed = speed;
    }

    public override void StartState()
    {
        _animator.SetBool("Walk", true);
     
    }

    public override void Run()
    {
     
        if (_controller.PlayerInputMovement == Vector3.zero)
        {
            _controller.SwitchMoveState<Idle>();
        }else
        {
            Move();
        }
    }

    public override void Stop()
    {
        _animator.SetBool("Walk", false);
        

    }
    private void Move()
    {
       
        
        Vector3 moveVector = _controller.transform.TransformDirection(_controller.PlayerInputMovement) * _speed;
        _controller.characterBody.velocity = new Vector3(moveVector.x, _controller.characterBody.velocity.y, moveVector.z);

    }
  
}

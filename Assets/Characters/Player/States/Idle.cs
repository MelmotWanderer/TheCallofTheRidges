
using UnityEngine;

public class Idle : State
{
    private PlayerController _controller;
    
    public Idle(PlayerController controller)
    {
        _controller = controller;
      
    }

    

    public override void Run()
    {
        if (_controller.PlayerInputMovement != Vector3.zero)
        {
            _controller.SwitchMoveState<Walk>();
        }
    }
}

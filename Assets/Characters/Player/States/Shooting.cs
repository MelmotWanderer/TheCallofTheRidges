using System.Collections;

using UnityEngine;

public class Shooting : State
{

    private PlayerController _playerController;
    private Animator _animator;
    private WeaponStateMachine _weaponStateMachine;
   
    public Shooting(PlayerController playerController,  Animator animator)
    {

        _playerController = playerController;

        _animator = animator;
     

    }

    public override void StartState()
    {
        _weaponStateMachine = _playerController.GetCurrentWeaponStateMachine();
        _weaponStateMachine.GetComponent<WeaponStateMachine>().StartShoot();
    }
    public override void Run()
    {
        Shoot();
    }

  
    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            
            if ( _playerController.PlayerInputMovement == Vector3.zero)
            {
                AnimationShoot();
            }

        }
        else
        {
            _playerController.SwitchShootState<NotShooting>();
        }
    }

    public override void Stop()
    {
        _weaponStateMachine.SwitchWeaponState<NotShoot>();
    }

    private void AnimationShoot()
    {
        _animator.Play("Shoot");
    }
}

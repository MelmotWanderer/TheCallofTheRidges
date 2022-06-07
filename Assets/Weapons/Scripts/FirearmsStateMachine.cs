using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmsStateMachine : WeaponStateMachine
{
    private Firearms _firearms;
    private Shell _shell;




    protected override void Init()
    {
        _firearms = GetComponent<Firearms>();
        _shell = _firearms.Shell;
        SetTypeShooting();
        _weaponStates = new List<State>()
        {
            new Shoot(_shooting, _shell, _firearms.GunPoint,_firearms.Damage, _firearms.Rate, _firearms.GetShootFire()),
            new NotShoot()
        };
        _currentState = SetDefaultState<NotShoot>();

    }

    protected virtual void SetTypeShooting()
    {
        _shooting = new MachineGunTypeShooting();
    }
    public override void StartShoot()
    {
        SwitchWeaponState<Shoot>();
    }
}

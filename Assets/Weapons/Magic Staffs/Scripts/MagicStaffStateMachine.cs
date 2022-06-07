using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MagicStaff))]
public class MagicStaffStateMachine : WeaponStateMachine
{
    private MagicStaff _magicStaff;
    private Spell _spell;



    protected override void Init()
    {
        _magicStaff = GetComponent<MagicStaff>();
        _spell = _magicStaff.GetCurrentSpell();

        _weaponStates = new List<State>()
        {
            new Cast(_shooting, _spell, _magicStaff.GunPoint, _magicStaff.Damage, _magicStaff.Rate),
            new NotShoot()
        };
       _currentState = SetDefaultState<NotShoot>();
    }

    public override void StartShoot()
    {
        SwitchWeaponState<Cast>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotShooting : State
{
    private IStateCharacterSwitcher _stateSwitcher;

    public NotShooting(IStateCharacterSwitcher stateSwitcher)
    {
        _stateSwitcher = stateSwitcher;
    }


    public override void StartState()
    {
       
    }
    public override void Run()
    {
        if (Input.GetButton("Fire1"))
        {
            _stateSwitcher.SwitchShootState<Shooting>();
        }
    }

    public override void Stop()
    {
       
    }
}

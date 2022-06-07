using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Weapon))]
public abstract class WeaponStateMachine: MonoBehaviour, IStateWeaponSwitcher
{
    protected List<State> _weaponStates;

    protected State _currentState;

    protected ITypeShooting _shooting;

    private void Start()
    {

        
        Init();
    }

    
    private void Update()
    {
   
        _currentState.Run();
    }





    public void SwitchWeaponState<T>() where T : State
    {
        var state = _weaponStates.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.StartState();
    }
    public State SetDefaultState<T>() where T : State
    {
        var state = _weaponStates.Find(s => s is T);

        return state;
    }
    protected abstract void Init();
    public abstract void StartShoot();
    
}

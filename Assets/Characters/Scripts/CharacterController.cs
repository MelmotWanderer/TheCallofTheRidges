
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character))]
public abstract class CharacterController: MonoBehaviour, IStateCharacterSwitcher
{
    protected State _currentState;
    protected State _stateAttack;
    protected List<State> _states;
    protected BloodEffect _particle;
    protected Character _character;

    private void Start()
    {
     
        _particle = GetComponent<BloodEffect>();
        _character = GetComponent<Character>();
        
        Init();
    }
    public virtual void GetDamage(float damage)
    {
       
        _character.GetDamage(damage);
        _particle.StartParticle();
    
        if (GetComponent<Character>().Health <= 0)
        {
            SwitchMoveState<Dead>();
        }

    }

    public void SwitchMoveState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.StartState();
    } 
    
    public void SwitchShootState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
        _stateAttack.Stop();
        _stateAttack = state;
        _stateAttack.StartState();
    }

    public State SetDefaultState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
       
        return state;
    }
    public void AddState<T>() where T : State
    {

        
        
    }

    protected abstract void Init();
}

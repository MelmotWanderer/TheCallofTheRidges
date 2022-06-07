using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Sun : MonoBehaviour, IStateSunSwticher
{
    public float Speed;
    public float TimeSpawnEnemy;
    public EnemySpawner _enemySpawner;
    public bool EnemyAttack;
    private List<State> _states;
    private State _currentState;
    private MusicSwitcher _musicSwitcher;
    


    [Inject]

    private void Construct(MusicSwitcher musicSwitcher)
    {
        _musicSwitcher = musicSwitcher;
    }

    private void Start()
    {
        _states = new List<State>()
        {
            new DayState(this, _musicSwitcher),
            new NightState(this, _musicSwitcher)
        };


        _currentState = _states[0];
    }


    private void Update()
    {

        transform.Rotate(new Vector3(Speed * Time.deltaTime, transform.rotation.y, transform.rotation.z));

        
        _currentState.Run();
        

    }


    public void SwitchSunState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.StartState();
    }


    public float GetRotationSun()
    {
        return transform.rotation.x;
    }

  
   
}

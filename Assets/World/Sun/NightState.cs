using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightState : State
{

    private Sun _sun;
    private float time;
    private float currentTime;
    private MusicSwitcher _musicSwitcher;
    public NightState(Sun sun, MusicSwitcher musicSwitcher)
    {
        _sun = sun;
        _musicSwitcher = musicSwitcher;
    }
    public override void StartState()
    {
        time = _sun.TimeSpawnEnemy;
        currentTime = 0;
        _sun.EnemyAttack = true;
        _musicSwitcher.StartNightMusic();
    }

    public override void Run()
    {
        if (_sun._enemySpawner.enabled)
        {

            currentTime += Time.deltaTime;

        if(currentTime >= time)
        {
           
                _sun._enemySpawner.RandomSpawn();
            }
           
            currentTime = 0;
        }


        if (_sun.transform.eulerAngles.x <= 10)
        {
            _sun.SwitchSunState<DayState>();
        }
    }

    public override void Stop()
    {
        _sun.EnemyAttack = false;
    }
}

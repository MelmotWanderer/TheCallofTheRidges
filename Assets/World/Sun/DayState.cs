using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayState : State
{
    private Sun _sun;
    private MusicSwitcher _musicSwitcher;
    public DayState(Sun sun, MusicSwitcher musicSwitcher)
    {
        _sun = sun;
        _musicSwitcher = musicSwitcher;
    }

    public override void StartState()
    {
        _musicSwitcher.StartMorningMusic();
    }
    public override void Run()
    {

       
     
        if(_sun.transform.eulerAngles.x > 180)
        {
            _sun.SwitchSunState<NightState>();
        }
    }
}

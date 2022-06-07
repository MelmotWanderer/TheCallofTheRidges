using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Zenject;
public class MusicSwitcher : MonoBehaviour
{
   [SerializeField] private EventReference MusicNight;
   [SerializeField] private EventReference MusicMorning;
  

    
  

    // Update is called once per frame
    private void Update()
    {
       
    }


    public void StartNightMusic()
    {
        RuntimeManager.PlayOneShot(MusicNight.Path);
    }
    public void StartMorningMusic()
    {
        RuntimeManager.PlayOneShot(MusicMorning.Path);
    }
   
}

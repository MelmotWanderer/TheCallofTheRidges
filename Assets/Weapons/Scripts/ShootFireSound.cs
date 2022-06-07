using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using FMODUnity;
public class ShootFireSound : MonoBehaviour
{
    
  
   
    public void PlayShootSound()
    {
        RuntimeManager.PlayOneShot("event:/Weapons/Rifles/Shoot");
    }
}

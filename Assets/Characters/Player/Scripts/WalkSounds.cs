using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class WalkSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySoundWalk()
    {
        RuntimeManager.PlayOneShot("event:/OneShots/Walk/Walking");
    }
}

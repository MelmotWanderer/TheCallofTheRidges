using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundWriting : MonoBehaviour
{

    private AudioSource _audioSource;
    public AudioClip soundWriting;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

   public void PlayWritingSound()
    {
        _audioSource.PlayOneShot(soundWriting);
    }
}

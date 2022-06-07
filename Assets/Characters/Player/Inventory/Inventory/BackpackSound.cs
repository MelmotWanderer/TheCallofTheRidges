using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackSound : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _soundOpening;
    public AudioClip _soundClosing;




    public void PlayOpenSound()
    {
        _audioSource.PlayOneShot(_soundOpening);
    }

    public void PlayCloseSound()
    {
        _audioSource.PlayOneShot(_soundClosing);
    }
}
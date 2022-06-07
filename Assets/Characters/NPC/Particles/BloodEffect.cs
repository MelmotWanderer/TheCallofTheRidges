using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class BloodEffect : MonoBehaviour
{
    [SerializeField] private VisualEffect _bloodEffect;
    [SerializeField] private Transform point;

  

    public void StartParticle()
    {
        var bloodEffect = Instantiate(_bloodEffect, point.position, Quaternion.identity);
        bloodEffect.Play();

    }
}

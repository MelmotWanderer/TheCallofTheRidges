using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
[RequireComponent(typeof(Weapon))]
public class ShootFire : MonoBehaviour
{

    public ParticleSystem _shootFire;
    public EventReference soundShoot;



    public void StartParticle(Transform gunPoint)
    {
        ParticleSystem particle = Instantiate(_shootFire, gunPoint);
        particle.Play();



    }
}

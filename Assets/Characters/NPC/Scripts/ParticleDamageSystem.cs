using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamageSystem: MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public Transform point;



    private void Start()
    {
        point = GetComponent<Character>().transform;
    }

    public void StartParticle()
    {
        var particle = Instantiate(_particleSystem, transform.position, Quaternion.identity);
        particle.Play();
       
    }
}

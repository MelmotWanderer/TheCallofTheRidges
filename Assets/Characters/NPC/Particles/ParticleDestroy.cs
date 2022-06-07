using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    [SerializeField] private float timeOnDestroy;




    private void Start()
    {
        Destroy(gameObject, timeOnDestroy);
    }
}

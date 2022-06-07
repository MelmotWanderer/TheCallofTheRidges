using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.VFX;
public class Spell : MonoBehaviour
{

    [SerializeField] private VisualEffect spellEffect;
   


    private void Start()
    {
        spellEffect.Stop();
    }

    public void Cast(Transform pointCast)
    {
     
            spellEffect.Play();
        
       
            Debug.Log("CAST!");
       
        
        

    }
    public void unCast()
    {
        spellEffect.Stop();
    }

    
}

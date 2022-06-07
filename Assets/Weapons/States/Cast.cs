using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : State
{

    private ITypeShooting _typeShooting;
    private Spell _spell;
    private Transform _gunPoint;
    private float _damage;
    private float _rate;


    public Cast(ITypeShooting typeShooting, Spell spell, Transform gunPoint, float damage, float rate)
    {
        _spell = spell;
        _gunPoint = gunPoint;
        _damage = damage;
        _rate = rate;
    }



    public override void StartState()
    {
        _spell.Cast(_gunPoint);
    }

    public override void Run()
    {
        
    }

    public override void Stop()
    {
        _spell.unCast();
    }
}

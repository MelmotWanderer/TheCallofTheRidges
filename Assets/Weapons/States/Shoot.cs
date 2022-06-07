using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : State
{
    private Shell _shell;
    private ITypeShooting _typeShooting;
   
    private Transform _gunPoint;
    private float _currentRate;
    private float _rate;
    private float _damage;
    private ShootFire _shootFire;
    public Shoot(ITypeShooting typeShooting, Shell shell, Transform gunPoint, float damage, float rate, ShootFire shootFire)
    {
        _shell = shell;
        _typeShooting = typeShooting;
        _gunPoint = gunPoint;
        _rate = rate;
        _damage = damage;
        _shootFire = shootFire;
    }


    public override void StartState()
    {
        _currentRate = _rate;
    }

    public override void Run()
    {
        _currentRate -= Time.deltaTime;

        if(_currentRate <= 0)
        {
            _typeShooting.Shoot(_shell, _gunPoint, _damage);
            _shootFire.StartParticle(_gunPoint);
            _currentRate = _rate;
        }

        
    }
}

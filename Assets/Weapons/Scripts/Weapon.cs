using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : MonoBehaviour
{

    public float Damage {get; private set; }
    public float Rate { get; private set; }
    public float Accuracy { get; private set; }
    public float AmmoCount {get; private set; }
    public Transform GunPoint;
    
    
    
    protected ShootFire _shootFire;
    protected float currentRate;

    [SerializeField] private float _damage;
    [SerializeField] private float _rate;
    [SerializeField] private float _accuracy; 
    [SerializeField] private float _ammoCount;
    

    private void Start()
    {
        Damage = _damage;
        Rate = _rate;
        Accuracy = _accuracy;
        AmmoCount = _ammoCount;

        _shootFire = GetComponent<ShootFire>();


        currentRate = 0;

        Init();
    }

    protected abstract void Init();


    public ShootFire GetShootFire()
    {
        return _shootFire;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
   


    protected override void Hit(IDamagable damagable)
    {
        damagable.GetDamage(_damage);
       
    }
}

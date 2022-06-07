using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherWeapon : MonoBehaviour, ISwitchWeapon
{

    public List<Weapon> _weapon;



    public void SwitchWeapon<T>() where T : Weapon
    {

    }
}

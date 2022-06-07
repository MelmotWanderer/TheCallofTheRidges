using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchWeapon 
{
    public void SwitchWeapon<T>() where T : Weapon;
}

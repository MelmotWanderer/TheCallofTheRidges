using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Firearms : Weapon
{


    public Shell Shell;

  
   


    protected override void Init()
    {
        Shell.SetSoundShootPath(_shootFire.soundShoot.Path);
    }

   
}

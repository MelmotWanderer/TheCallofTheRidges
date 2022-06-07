using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTypeShooting : MonoBehaviour, ITypeShooting
{



    public void Shoot(Shell shell, Transform gunPoint, float damage)
    {
        var shellObject = Instantiate(shell, gunPoint.position, gunPoint.rotation);
        shellObject.SetDamage(damage);
        shellObject.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 150.0f);
        
        
    }


}

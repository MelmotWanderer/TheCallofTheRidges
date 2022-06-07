
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public float Health;
    


   
    public void GetDamage(float damage)
    {
        if (Health > 0)
        {
            Health -= damage;
     
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class CollisionWeapon : MonoBehaviour
{


    private float _damage;


    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage(_damage);
            
        }
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
     
    }
}

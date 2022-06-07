using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[RequireComponent(typeof(BoxCollider))]
public class ItemTrigger : MonoBehaviour
{
    private BoxCollider boxCollider;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;

    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
          
            if (Input.GetButtonDown("Interact"))
            {
              
                _player.GetComponent<PlayerInventory>().AddItem(GetComponentInParent<Item>());
                GetComponentInParent<Item>().PickUp();
             
            }
            
        }
    }



}

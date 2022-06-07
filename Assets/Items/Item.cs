using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Item : MonoBehaviour, IItem
{
    public ItemData Data;

    public int index = -1;

    private Player _player;
    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        index = -1;
        
    }
    public void PickUp()
    {
        
        
        gameObject.SetActive(false);
        
    }

    public void Drop()
    {
       
        this.transform.position = _player.transform.position;
        gameObject.SetActive(true);
        
        index = -1;
    }

   
}

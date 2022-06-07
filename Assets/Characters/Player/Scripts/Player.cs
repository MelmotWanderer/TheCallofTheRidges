using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float Money { get; private set; }
    public List<Weapon> Weapons = new List<Weapon>();



    private void Start()
    {
      
    }
}

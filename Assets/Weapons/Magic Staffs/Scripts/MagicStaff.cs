using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaff : Weapon
{


    [SerializeField] private List<Spell> _spells;
    private Spell _currentSpell;



    protected override void Init()
    {
        InitSpells();
       
        
    }

    public Spell GetCurrentSpell()
    {
        return _currentSpell;
    }
    private void InitSpells()
    {
        foreach(Spell spell in _spells)
        {
            var spellObject = Instantiate(spell.gameObject, GunPoint.position, GunPoint.rotation);
            _currentSpell = spellObject.GetComponent<Spell>();
            spellObject.transform.parent = this.transform;
        }
    }

    
}

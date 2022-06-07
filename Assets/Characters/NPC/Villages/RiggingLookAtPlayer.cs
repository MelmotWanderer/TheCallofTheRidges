using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;
public class RiggingLookAtPlayer : MonoBehaviour
{

    private Transform _player;
    [SerializeField] private RigBuilder _rigBuilder;
   [SerializeField] private MultiAimConstraint _constraint;

    [Inject] 
    private void Construct(Player player)
    {
        _player = player.GetComponent<Transform>();
        
    }



    private void Start()
    {
      
        var data = _constraint.data.sourceObjects;
        data.SetTransform(0, _player);
        _constraint.data.sourceObjects = data;
        _rigBuilder.Build();
    }

    
}

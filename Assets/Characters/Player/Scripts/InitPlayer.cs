using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Zenject;
public class InitPlayer : MonoBehaviour 
{

    private Transform _player;

        [Inject]
        private void Construct(Player player)
        {
        _player = player.transform;
        
        }

    private void Start()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = _player;
    }

}

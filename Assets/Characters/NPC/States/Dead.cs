using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : State
{

    private CharacterController _characterController;
    public Dead(CharacterController characterController)
    {
        _characterController = characterController;
    }


    public override void Run()
    {
        Destroy(_characterController.gameObject);
    }
}

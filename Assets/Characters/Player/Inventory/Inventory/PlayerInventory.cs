using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[RequireComponent(typeof(PlayerController))]
public class PlayerInventory : Storage
{


    private bool isActive = false;
    
    public BackpackSound _backpackSound;
    
    [Inject]

    private void Construct(InventoryUI StorageUI, PlayerUI playerUI, CameraPosition cameraPosition)
    {
        _storageUI = StorageUI;
        _playerUI = playerUI;
        _cameraPosition = cameraPosition;
    }

    private void Start()
    {
       

        _playerController = GetComponent<PlayerController>();
        _rotatorPlayer = _playerController.GetComponentInChildren<Rotator>();
     
     

    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ActiveStorageUI(!isActive);

             isActive = !isActive;
            if (isActive)
            {
                OpenStorage();
               
            }
            else
            {
             
                CloseStorage();
            }
         

        }
    }


    public override void OpenStorage()
    {
        DisablePlayer();
        _storageUI.SetInventory(this);
        if(_backpackSound != null)
        {
            _backpackSound.PlayOpenSound();
        }
        
    }
    public override void CloseStorage()
    {
        EnablePlayer();
        if (_backpackSound != null)
        {
            _backpackSound.PlayCloseSound();
        }
            
    }

}

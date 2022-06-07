using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Container : Storage
{
    private Player _player;
    private Animator _animator;




    [Inject]

    private void Construct(Player player, ContainerUI StorageUI, PlayerUI playerUI, CameraPosition cameraPosition)
    {
        _player = player;
        _storageUI = StorageUI;
        _playerUI = playerUI;
        
        _cameraPosition = cameraPosition;
    }

    private void Start()
    {
      if(GetComponent<Animator>())
        {
            _animator = GetComponent<Animator>();
        }
       
        _playerController = _player.GetComponent<PlayerController>();
        _rotatorPlayer = _player.GetComponentInChildren<Rotator>();
        DisableAllItem();
        _storageUI.SetInventory(this);
    }
    public override void OpenStorage()
    {
        DisablePlayer();
        _storageUI.SetInventory(this);
        PlayAnimationOpen();
    }public override void CloseStorage()
    {
        EnablePlayer();
        PlayAnimationClose();
    }
    public void PlayAnimationOpen()
    {
        _animator.SetTrigger("Open");
    }
    public void PlayAnimationClose()
    {
        _animator.SetTrigger("Close");
    }
    private void DisableAllItem()
    {
        foreach(Item item in _items)
        {
            item.gameObject.SetActive(false);
        }
    }
}

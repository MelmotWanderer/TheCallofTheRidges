using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public abstract class Storage : MonoBehaviour
{
    public List<Item> _items;

    public int CountCells;
    public Vector3 positionCamera;
    public Quaternion rotationPlayer;
   
    protected Rotator _rotatorPlayer;
    protected CameraPosition _cameraPosition;
    protected PlayerUI _playerUI;
    protected ContainerUI _storageUI;
    protected PlayerController _playerController;






    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);

    }




   virtual public void OpenStorage()
    {
        DisablePlayer();
        _storageUI.SetInventory(this);

    }
    virtual public void CloseStorage()
    {
        EnablePlayer();
    }
    protected void DisablePlayer()
    {
        _rotatorPlayer.SetRotation(rotationPlayer);
        _rotatorPlayer.Disable();
        _playerController.Unequip();
        _cameraPosition.SwitchPosition(positionCamera, Quaternion.identity);
        _playerUI.Disable();
    }
    protected void EnablePlayer()
    {
        _rotatorPlayer.Enable();
        _playerController.Equip();
        _cameraPosition.SwitchPosition(_cameraPosition.CameraPositionDefault, Quaternion.Euler(55.0f, 0, 0));
        _playerUI.Enable();
    }

    public void ActiveStorageUI(bool isActive)
    {
        _storageUI.SetActive(isActive);
    }


    
  
}

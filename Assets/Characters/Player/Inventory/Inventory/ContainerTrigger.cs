using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ContainerTrigger : MonoBehaviour
{

    private Container _container;
    private bool isOpen;

    private void Start()
    {
        _container = GetComponentInParent<Container>();
        isOpen = false;

    }



    private void OnTriggerStay(Collider other)
    {
        if (!isOpen)
        {
            if (other.GetComponent<Player>())
            {

                if (Input.GetButtonDown("Interact"))
                {
                    _container.OpenStorage();
                    _container.ActiveStorageUI(true);
                    _container.PlayAnimationOpen();
                    
                    other.GetComponent<Player>().GetComponent<PlayerInventory>().OpenStorage();
                    other.GetComponent<Player>().GetComponent<PlayerInventory>().ActiveStorageUI(true);
                    isOpen = true;
                }

            }
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {

            _container.ActiveStorageUI(false);
            _container.CloseStorage();
            _container.PlayAnimationClose();
            other.GetComponent<Player>().GetComponent<PlayerInventory>().CloseStorage();
            other.GetComponent<Player>().GetComponent<PlayerInventory>().ActiveStorageUI(false);
            isOpen = false;

        }
    }

}

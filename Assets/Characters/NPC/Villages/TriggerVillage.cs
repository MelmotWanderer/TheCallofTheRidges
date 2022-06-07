using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class TriggerVillage : MonoBehaviour
{

    private bool _isBlock;
    private DialogeUI _dialogeUI;
    [SerializeField] private Interactive interactiveVillage;
   
    [Inject]
    private void Construct(DialogeUI dialogeUI)
    {
       
        _dialogeUI = dialogeUI;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            if (!_isBlock)
                {
                  _dialogeUI.ActiveInteractMessage(true);
                }
            else
                {
                _dialogeUI.ActiveInteractMessage(false);
                }
      
        _dialogeUI.SetInteractMessage(interactiveVillage.Name);
        if (Input.GetButtonDown("Interact") && _isBlock == false)
        {
           
                interactiveVillage.Interact();
                _isBlock = true;
            }
           
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.GetComponent<Player>() != null)
        {

            interactiveVillage.UnInteract();
            _isBlock = false;
            _dialogeUI.ActiveInteractMessage(false);
        }
      
    }
    
}

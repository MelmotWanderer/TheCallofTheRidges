using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class InteractiveDialoge : Interactive
{

    
    public List<Dialogue> Dialoge;
    [SerializeField] private SoundWriting _soundWriting;
    [SerializeField] private Vector3 CameraPositionDialoge;
    [SerializeField] private CameraPosition _cam;
 
    private PlayerUI _ui;
    private Player _player;
    private DialogeUI _dialogeUI;
    private Action _interact;
    private Action _unInteract;   
    private int currentDialog = 0;
  

    [Inject]
    private void Construct(PlayerUI ui, DialogeUI dialogeUI,Player player)
    {
        _ui = ui;
        _player = player;
        _dialogeUI = dialogeUI;
    }

    private void Start()
    {
       
        InitInteract();
        InitUnInteract();

    }

    public override void Interact()
    {
        _dialogeUI.SetDialogueNPC(this);
        _dialogeUI.SetName(Name);
        _dialogeUI.SetWritingSound(_soundWriting);
        _cam.SwitchPosition(CameraPositionDialoge, Quaternion.identity, gameObject.transform);
        _interact?.Invoke();
      
    }


    public Saying SwitchSaying(int currentSaying)
    {
        var saying = Dialoge[currentDialog].Sayings[currentSaying];
        if (saying.SwitchDialogue)
        {
            SwitchDialogue();
        }
        return saying;
    }
    public override void UnInteract()
    {
        _dialogeUI.SetDialogueNPC(null);
        _cam.SwitchPosition(_cam.CameraPositionDefault, Quaternion.Euler(55, 0, 0), null);
        _unInteract?.Invoke();
        if (Dialoge[currentDialog].isTemporary)
        {
            SwitchDialogue();
        }
      
    }

    private void InitInteract()
    {
        _interact += _ui.Disable;
        _interact += _dialogeUI.Enable;
        _interact += _dialogeUI.Up;
      
        _interact += delegate { _player.GetComponentInChildren<Rotator>().LookAtNPC(gameObject.transform); };
        _interact += _player.GetComponent<PlayerController>().Unequip;
       
        
    }
    private void InitUnInteract()
    {
        _unInteract += _ui.Enable;
    
        _unInteract += _dialogeUI.Down;
      
        _unInteract += _player.GetComponent<PlayerController>().Equip;
        _unInteract +=  _player.GetComponentInChildren<Rotator>().DisableLookAt;

    }

    public void SwitchDialogue()
    {
        currentDialog += 1;
    }
}

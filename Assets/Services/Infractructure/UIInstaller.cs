using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class UIInstaller : MonoInstaller
{

    public PlayerUI Ui;
    public DialogeUI DialogeUI;
    public InventoryUI InventoryUI;
    public ContainerUI ContainerUI;

    public override void InstallBindings()
    {
        UIBind();
    }



    private void UIBind()
    {
        Container.Bind<PlayerUI>().FromInstance(Ui).AsSingle();
        Container.Bind<DialogeUI>().FromInstance(DialogeUI).AsSingle();
        Container.Bind<InventoryUI>().FromInstance(InventoryUI).AsSingle();
        Container.Bind<ContainerUI>().FromInstance(ContainerUI).AsSingle();
    }
}

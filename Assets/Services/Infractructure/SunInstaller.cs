using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SunInstaller : MonoInstaller
{


    public Sun _sun;

    public override void InstallBindings()
    {
        BindSun();
    }



    private void BindSun()
    {
        Container.Bind<Sun>().FromInstance(_sun).AsSingle();
    }
}

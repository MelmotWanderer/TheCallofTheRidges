using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject; 
public class CameraInstaller : MonoInstaller
{


    public CameraPosition cameraPosition;
    public override void InstallBindings()
    {
        BindCamera();
    }
    private void BindCamera()
    {
        Container.Bind<CameraPosition>().FromInstance(cameraPosition).AsSingle();
    }
}

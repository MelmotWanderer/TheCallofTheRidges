using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class EnemyInstaller : MonoInstaller
{




    public override void InstallBindings()
    { 

        BindEnemyInstaller();
        BindEnemyFactory();
        
        
    }

 
    private void BindEnemyInstaller()
    {
        Container.BindInterfacesTo<EnemyInstaller>().FromInstance(this).AsSingle();
    }

    private void BindEnemyFactory()
    {
        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
    }
}

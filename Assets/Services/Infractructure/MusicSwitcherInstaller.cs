using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class MusicSwitcherInstaller : MonoInstaller
{

    public MusicSwitcher _musicSwitcher;


    public override void InstallBindings()
    {
        BindMusicSwitcher();
    }



    private void BindMusicSwitcher()
    {
        Container.Bind<MusicSwitcher>().FromInstance(_musicSwitcher).AsSingle();
    }
}

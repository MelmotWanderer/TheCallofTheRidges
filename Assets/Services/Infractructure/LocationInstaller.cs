
using UnityEngine;
using Zenject;
public class LocationInstaller : MonoInstaller
{


    public Transform StartPoint;
    public GameObject playerPrefab;


    public override void InstallBindings()
    {
        BindPlayer();
       
    }

 

    private void BindPlayer()
    {
        Player player= Container.InstantiatePrefabForComponent<Player>(playerPrefab, StartPoint.position, Quaternion.identity, null);
      Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
    }
}

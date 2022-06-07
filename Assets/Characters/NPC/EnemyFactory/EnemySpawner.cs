using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class EnemySpawner: MonoBehaviour
{

    private IEnemyFactory _enemyFactory;

   [SerializeField] private CharacterAI[] _enemyPrefabs;
   
    public List<EnemyMarker> enemysMarkers;

    [Inject]
    private void Construct(IEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {

        Spawn();
    }


   public void Spawn()
    {
        foreach (EnemyMarker enemyMarker in enemysMarkers)
        {
            _enemyFactory.Create(enemyMarker.GetEnemyPrefab(), enemyMarker.transform.position, enemyMarker.IsActiveEnemy(), enemyMarker.GetWayPoints());

        }
        enemysMarkers.Clear();
    }

  public void RandomSpawn()
    {
        _enemyFactory.Create(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], new Vector3(Random.Range(-4, 13), 0, Random.Range(-23, 12)), true, null);
    }
}

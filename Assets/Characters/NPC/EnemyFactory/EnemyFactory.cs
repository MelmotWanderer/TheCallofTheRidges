using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

    public class EnemyFactory : IEnemyFactory
    {

        private readonly DiContainer _diContainer;

        
        public EnemyFactory(DiContainer diContainer)
         {
              _diContainer = diContainer;
         }


        public void Create(CharacterAI enemyPrefab, Vector3 position, bool isActiveEnemy, List<Transform> wayPoints)
        {
         var enemy = _diContainer.InstantiatePrefab(enemyPrefab, position, Quaternion.identity, null);
        enemy.GetComponent<AttackAIController>().IsActiveEnemy = isActiveEnemy;     
       if(wayPoints != null)
        enemy.GetComponent<AttackAIController>().SetListWayPoints(wayPoints);
        }
    
        
    }


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public interface IEnemyFactory 
{

    public void Create(CharacterAI enemyPrefab, Vector3 position, bool isActiveEnemy, List<Transform> wayPoints);




}

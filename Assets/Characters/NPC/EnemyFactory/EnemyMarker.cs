using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarker : MonoBehaviour
{
    [SerializeField] private CharacterAI _enemy;
    [SerializeField] private bool _isActiveEnemy;
    [SerializeField] private List<Transform> _wayPoints;
    public CharacterAI GetEnemyPrefab()
    {
        return _enemy;
    }

    public bool IsActiveEnemy()
    {
        return _isActiveEnemy;
    }

    public List<Transform> GetWayPoints()
    {
        return _wayPoints;
    }
}

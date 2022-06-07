

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
[RequireComponent(typeof(NavMeshAgent))]
public abstract class AttackAIController : CharacterController, IDamagable
{

    public int indexCurrenWayPoint { get; private set; }
    public Vector3 currentTargetMove { get; private set; }

    public bool IsActiveEnemy;
    public float _attackMeleeDistance;
    [SerializeField] private List<Transform> _wayPoints;
    public CollisionWeapon _collisionWeapon;
    protected NavMeshAgent _navMesh;
    protected Animator _animator;
    protected Transform _player;
    protected float _damage;

    protected Sun _sun;
    


    [Inject]
    private void Construct(Player player, Sun sun)
    {
        _player = player.transform;
        _sun = sun;
    }
  
  protected override void Init()
    {
        
        _damage = GetComponent<CharacterAI>().Damage;
        
        _collisionWeapon.SetDamage(_damage);

        _collisionWeapon.GetComponent<Collider>().enabled = false;

        _animator = GetComponent<Animator>();
        _navMesh = GetComponent<NavMeshAgent>();
        _states = new List<State>()
        {
            new IdleAI(this, _wayPoints.Count, _sun),
            new SearchTargetMove(this, _wayPoints),
            new WalkAI(this, _navMesh, _wayPoints, _animator),
            new Dead(this),
           
        };
        _currentState = SetDefaultState<IdleAI>();
        InitEnemy();


    }

    private void Update()
    {
        if (!isPlayerAlive())
        {
            SwitchMoveState<IdleAI>();
        }

        _currentState.Run();
    }


    public void ChangeIndexCurrentPatrolPoint(int index) {
        indexCurrenWayPoint = index;
    }

    public void SetTarget(Vector3 target)
    {
        currentTargetMove = target;
    }
    
    

    public Transform GetPlayerTransform()
    {
       
            return _player;

    }

    public bool isPlayerAlive()
    {
        if(_player == null)
        {
            return false;
        }
        return true;
    }

    public override void GetDamage(float damage)
    {
        _character.GetDamage(damage);
        _particle.StartParticle();
        SwitchMoveState<RunningAI>();
        if (_character.Health <= 0)
        {
            SwitchMoveState<Dead>();
        }
    }
  
    public void SetListWayPoints(List<Transform> wayPoints)
    {
        _wayPoints = wayPoints;
    }
    protected abstract void InitEnemy();
    abstract public void StartAttack();
}

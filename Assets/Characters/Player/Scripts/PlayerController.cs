
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : CharacterController
{
    public Rigidbody characterBody;
    public Vector3 PlayerInputMovement { get; private set; }
   
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Quaternion rotationWeapon;

    private int indexCurrentWeapon;




    private void Update()
    {
        SwitchWeapon();
        UpdateMovement();
        _currentState.Run();
        _stateAttack.Run();

    }

    protected override void Init()
    {
        if (_currentWeapon == null)
        {
            PickWeaponInHand(0);
        }


        _states = new List<State>()
        {
            new Idle(this),
            new Walk(this, _speed, _animator),
            new Shooting(this, _animator),
            new NotShooting(this),
            new NotEquipped(),
            new Dead(this)
            
        };

        _currentState = SetDefaultState<Idle>();
        _stateAttack = SetDefaultState<NotShooting>();

    }
    private void SwitchWeapon()
    {
        if (Input.GetButtonDown("SwitchWeapon"))
        {
            int x =  indexCurrentWeapon + 1;
         
            if (x == GetComponent<Player>().Weapons.Count) x = 0;

            PickWeaponInHand(x);
        }
    }
    public void PickWeaponInHand(int x)
    {
        var newWeapon = GetComponent<Player>().Weapons[x];
        if (_currentWeapon != null)
        {
            Destroy(_currentWeapon.gameObject);
        }
        newWeapon.transform.rotation = rotationWeapon;

        indexCurrentWeapon = x;


        _currentWeapon = (Weapon)Instantiate(newWeapon, _weaponContainer);
    }

    private void UpdateMovement()
    {
        PlayerInputMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    public WeaponStateMachine GetCurrentWeaponStateMachine()
    {
        return _currentWeapon.GetComponent<WeaponStateMachine>();
    }
    public void Equip()
    {
        SwitchShootState<NotShooting>();
    }
    public void Unequip()
        {
        SwitchShootState<NotEquipped>();
    }
    
   
}

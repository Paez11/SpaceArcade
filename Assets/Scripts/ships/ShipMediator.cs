using Ships.CheckLimits;
using Inputs;
using UnityEngine;
using Input = Inputs.Input;
using System;
using Ships.Weapons;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        
        private Input _input;

        public void Configure(Input input, CheckLimit checkLimits)
        {
            _input = input;
            _movementController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }

        // Update is called once per frame
        void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if(_input.IsFireActionPressed())
                _weaponController.TryShoot();
            if(_input.IsMissileActionPressed())
                _weaponController.TryShootMissile();
        }
    }
}


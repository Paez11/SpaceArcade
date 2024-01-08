using UnityEngine;
using Input = Inputs.Input;
using Ships.Weapons;
using Ships.Common;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        
        [SerializeField] private ShipId _shipid;
        public string Id => _shipid.Value;
        private Input _input;

        public void Configure(shipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId);
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


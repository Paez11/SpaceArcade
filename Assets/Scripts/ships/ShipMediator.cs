using UnityEngine;
using Input = Inputs.Input;
using Ships.Weapons;
using Ships.Common;
using System;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;
        
        [SerializeField] private ShipId _shipid;
        public string Id => _shipid.Value;
        private Input _input;
        private Teams _team;

        public void Configure(shipConfiguration configuration)
        {
            _input = configuration.Input;
            _movementController.Configure(this, configuration.CheckLimits, configuration.Speed);
            _weaponController.Configure(this, configuration.FireRate, configuration.DefaultProjectileId, configuration.Team);
            _healthController.Configure(this, configuration.Health, configuration.Team);
            _team = configuration.Team;
        }

        private void FixedUpdate() 
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            //TryShoot();
        }

        /*
        // Update is called once per frame
        void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }
        */

        private void TryShoot()
        {
            if(_input.IsFireActionPressed())
                _weaponController.TryShoot();
            if(_input.IsMissileActionPressed())
                _weaponController.TryShootMissile();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var damageable = other.GetComponent<Damageable>();
            if(damageable.Team == _team)
            {
                return;
            }
            damageable.AddDamage(1);
            Debug.Log("Ship collided: " + other.name);    
        }

        public void OnDamageRecived(bool isDeath)
        {
            if(isDeath)
            {
                Destroy(gameObject);
            }
        }
    }
}


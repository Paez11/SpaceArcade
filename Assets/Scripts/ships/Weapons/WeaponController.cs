using System;
using System.Linq;
using Ships.Common;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        private Ship _ship; 
        private float _remainingSecondsToBeAbleShoot;
        private float _remainingSecondsToBeAbleShootMissile;
        private float _fireRateInSeconds;
        [SerializeField] private float _missileFireRateInSeconds;
        [SerializeField] private Transform _projectileSpawnPosition;

        private string _activeProjectileId;
        [SerializeField] private ProjectileId _defaultProjectileId;
        private ProjectileFactory _projectileFactory;
        [SerializeField] private ProjectilesConfiguration _projectileConfiguration;
        private Teams _team;

        private void Awake() 
        {
            var instance = Instantiate(_projectileConfiguration);
            _projectileFactory = new ProjectileFactory(instance);
        }

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            _ship = ship;
            _activeProjectileId = defaultProjectileId.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
            
        }
        internal void TryShoot()
        {
            _remainingSecondsToBeAbleShoot -= Time.deltaTime;
            if(_remainingSecondsToBeAbleShoot > 0)
                return;
            Shoot();
        }
        internal void TryShootMissile()
        {
            _remainingSecondsToBeAbleShootMissile -= Time.deltaTime;
            if(_remainingSecondsToBeAbleShootMissile > 0)
                return;
            ShootMissile();
        }

        private void ShootMissile()
        {
            _remainingSecondsToBeAbleShootMissile = _missileFireRateInSeconds;
            Instantiate(_defaultProjectileId,_projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }

        private void Shoot()
        {
            var projectile = _projectileFactory.Create(_activeProjectileId, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation, _team);
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
        }
    }
}

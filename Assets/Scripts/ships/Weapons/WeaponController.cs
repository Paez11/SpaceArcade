using System;
using System.Linq;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        private Ship _ship; 
        private float _remainingSecondsToBeAbleShoot;
        private float _remainingSecondsToBeAbleShootMissile;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private float _missileFireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;

        private string _activeProjectileId;

        public void Configure(Ship ship)
        {
            _ship = ship;
            _activeProjectileId = "Projectile1";
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
            Instantiate(_projectilePrefabs[1],_projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }

        private void Shoot()
        {
            var prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}

using System;
using Inputs;
using Ships.CheckLimits;
using UnityEngine;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipConfiguration;
        private ShipFactory _shipFactory;
        private float _currentTimeInSeconds;
        private int _currentCondfigurationIndex;

        private void Awake() {
            _shipFactory = new ShipFactory(Instantiate(_shipConfiguration));
        }

        private void Update() {

            if(_currentCondfigurationIndex >= _levelConfiguration.SpawnConfiguration.Length)
                return;

            _currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = _levelConfiguration.SpawnConfiguration[_currentCondfigurationIndex];
            if(spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
                return;

            SpawnShips(spawnConfiguration);
            _currentCondfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (var i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                var spawnPosition = _spawnPositions[i % _spawnPositions.Length];
                var ship = _shipFactory.Create(shipConfiguration.ShipId.Value,
                                               spawnPosition.position,
                                               spawnPosition.rotation);
                ship.Configure(new AIInputAdapter(ship), 
                               new InitialPositionCheckLimits(ship.transform, 10f),
                               shipConfiguration.Speed,
                               shipConfiguration.FireRate,
                               shipConfiguration.DefaultProjectileId);
            }
        }
    }
}

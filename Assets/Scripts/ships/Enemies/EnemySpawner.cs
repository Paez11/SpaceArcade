using System;
using Inputs;
using Ships.CheckLimits;
using Ships.Common;
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
                var shipBuilder = _shipFactory.Create(shipConfiguration.ShipId.Value);
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai)
                    .WithPosition(spawnPosition.position)
                    .WithRotation(spawnPosition.rotation)
                    .WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.InitialPosition)
                    .WithConfiguration(shipConfiguration).Build();
            }
        }
    }
}

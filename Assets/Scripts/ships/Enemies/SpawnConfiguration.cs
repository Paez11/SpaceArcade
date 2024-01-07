using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Enemies
{
    [Serializable]
    public class SpawnConfiguration
    {
        [SerializeField] private ShipToSpawnConfiguration[] _shipToSpawnConfiguration;
        [SerializeField] private float _timeToSpawn;

        public ShipToSpawnConfiguration[] ShipToSpawnConfigurations => _shipToSpawnConfiguration;
        public float TimeToSpawn => _timeToSpawn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Enemies
{
    [CreateAssetMenu(menuName = "Create LevelConfiguration", fileName = "LevelConfiguration", order = 0)]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private SpawnConfiguration[] _spawnConfiguration;

        public SpawnConfiguration[] SpawnConfiguration => _spawnConfiguration;
    }
}

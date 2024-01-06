using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName ="Create ShipsConfiguration", fileName = "ShipsConfiguration", order = 0)]
    public class ShipsConfiguration : ScriptableObject
    {
        [SerializeField] private ShipMediator[] _shipPrefabs;
        private Dictionary<string, ShipMediator> _idToShipPrefab;

        private void Awake() 
        {
            _idToShipPrefab = new Dictionary<string, ShipMediator>();
            foreach(var ship in _shipPrefabs)
            {
                _idToShipPrefab.Add(ship.Id, ship);
            }
        }

        public ShipMediator GetShipId(string id)
        {
            if(!_idToShipPrefab.TryGetValue(id, out var ship))
                throw new System.Exception($"Projectile {id} not found");
            return ship;
        }
    }
}

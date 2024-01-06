using UnityEngine;

namespace Ships
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Ship Create(string id, Vector3 position, Quaternion rotation)
        {
            var prefab = _configuration.GetShipId(id);
            return Object.Instantiate(prefab, position, rotation);
        }
    }
}

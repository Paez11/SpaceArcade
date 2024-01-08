using UnityEngine;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;

        public ShipFactory(ShipsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ShipBuilder Create(string id)
        {
            var prefab = _configuration.GetShipId(id);
            return new ShipBuilder().FromPrefab(prefab);
        }
    }
}

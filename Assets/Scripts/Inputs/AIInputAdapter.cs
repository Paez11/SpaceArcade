using Ships;
using UnityEngine;

namespace Inputs
{
    public class AIInputAdapter : Input
    {
        private readonly ShipMediator _ship;
        private int _currentDirectionX;
        public AIInputAdapter(ShipMediator ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
        }
        public Vector2 GetDirection()
        {
            var viewportPoin = Camera.main.WorldToViewportPoint(_ship.transform.position);
            if(viewportPoin.x < 0.05f)
            {
                _currentDirectionX = 1;
            }
            else if(viewportPoin.x > 0.95f)
            {
                _currentDirectionX = -1;
            }
            return new Vector2(_currentDirectionX, 0);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }

        public bool IsMissileActionPressed()
        {
            throw new System.NotImplementedException();
        }
    }
}


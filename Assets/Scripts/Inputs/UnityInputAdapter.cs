using UnityEngine;

namespace Inputs
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            var horizontal = UnityEngine.Input.GetAxis("Horizontal");
            var vertical = UnityEngine.Input.GetAxis("Vertical");

            return new Vector2(horizontal, vertical);
        }

        public bool IsFireActionPressed()
        {
            return UnityEngine.Input.GetButton("Fire1");
        }

        public bool IsMissileActionPressed()
        {
            return UnityEngine.Input.GetButton("Fire2");
        }
    }
}
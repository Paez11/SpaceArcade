using Ships.CheckLimits;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Vector2 _speed;
        private Transform _myTransform;
        private CheckLimit _checkLimits;
        private Ship _ship;
        
        private void Awake() 
        {
            _myTransform = transform;
        }
        public void Configure(Ship ship, CheckLimit checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            //ClampFinalPosition();
            _checkLimits.ClampFinalPosition();
        }
    }
}


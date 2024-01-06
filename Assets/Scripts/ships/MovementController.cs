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
        public void Configure(Ship ship, CheckLimit checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits; 
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            //ClampFinalPosition();
            _checkLimits.ClampFinalPosition();
        }
    }
}


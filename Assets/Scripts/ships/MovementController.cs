using Ships.CheckLimits;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Vector2 _speed;
        //private Transform _myTransform;
        private CheckLimit _checkLimits;
        private Ship _ship;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _currentPosition;

        private void Awake() 
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _currentPosition = _rigidbody2D.position;
        }
        public void Configure(Ship ship, CheckLimit checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _currentPosition += direction * (_speed * Time.deltaTime);
            _currentPosition = _checkLimits.ClampFinalPosition(_currentPosition);
            _rigidbody2D.MovePosition(_currentPosition);
            //_myTransform.Translate(direction * (_speed * Time.deltaTime));
            //ClampFinalPosition();
        }
    }
}


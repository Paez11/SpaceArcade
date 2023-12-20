using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _amplitude;
        [SerializeField] private float frequency;
        private Vector3 _currentPosition;
        private float _currentTime;

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = transform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            //horizontalPosition = amplitude * sin(x * frequency);
            var horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * frequency));
           _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

           _currentTime += Time.deltaTime; 
        }

        protected override void DoDestroy()
        {
        }
    }
}

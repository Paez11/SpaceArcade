using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _horizontalPosition;

        private Vector3 _currentPosition;
        private float _currentTime;

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = _myTransform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            //horizontalPosition = amplitude * sin(x * frequency);
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
           _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

           _currentTime += Time.deltaTime; 
        }

        protected override void DoDestroy()
        {
        }
    }
}

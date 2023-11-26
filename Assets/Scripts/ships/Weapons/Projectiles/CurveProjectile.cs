using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CurveProjectile : Projectile
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _horizontalPosition;

        private Vector3 _currentPosition;
        private float _currentTime;
        private Transform _myTransform;

        private void Start() 
        {
            _currentTime = 0;
            _myTransform = transform;
            _currentPosition = transform.position;
            StartCoroutine(DestroyIn(4f));
        }

        private void FixedUpdate() 
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            //horizontalPosition = amplitude * sin(x * frequency);
            var horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
           _rigidbody2D.MovePosition(_currentPosition + horizontalPosition);

           _currentTime += Time.deltaTime; 
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}

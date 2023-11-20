using Ships.CheckLimits;
using Inputs;
using UnityEngine;
using Input = Inputs.Input;
using System;
using Ships.Weapons;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Input _input;
        private Transform _myTransform;
        private CheckLimit _checkLimits;
        private float _remainingSecondsToBeAbleShoot;
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _projectileSpawnPosition;

        // Start is called before the first frame update
        private void Awake() 
        {
            _myTransform = transform;    
        }

        public void Configure(Input input, CheckLimit checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        // Update is called once per frame
        void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            _remainingSecondsToBeAbleShoot -= Time.deltaTime;
            if(_remainingSecondsToBeAbleShoot > 0)
                return;
            if(_input.IsFireActionPressed())
                Shoot();
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            //ClampFinalPosition();
            _checkLimits.ClampFinalPosition();
        }

        //Funcion para que no pueda ir el objeto más allá del borde de la cámara
        /*
        private void ClampFinalPosition()
        {
            var viewportPoin = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoin.x = Mathf.Clamp(viewportPoin.x, 0.03f, 0.97f);
            viewportPoin.y = Mathf.Clamp(viewportPoin.y, 0.03f, 0.97f);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoin);
        }
        */

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
            //return new Vector2(_joystick.Horizontal, _joystick.Vertical);
            //var horizontalDir = Input.GetAxis("Horizontal");
            //var verticalDir = Input.GetAxis("Vertical");
            //return new Vector2(horizontalDir, verticalDir);
        }
    }
}


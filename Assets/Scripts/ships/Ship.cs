using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Input _input;
        private Transform _myTransform;
        private CheckLimits _checkLimits;
        // Start is called before the first frame update
        private void Awake() 
        {
            _myTransform = transform;    
        }

        public void Configure(Input input, CheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        // Update is called once per frame
        void Update()
        {
            var direction = GetDirection();
            Move(direction);
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


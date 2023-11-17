using System;
using UnityEngine;

namespace ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useIA;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake() 
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }

        private CheckLimits GetCheckLimitsStrategy()
        {
            if(_useIA)
                return new InitialPositionCheckLimits(_ship.transform, 10f);
            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }

        private Input GetInput()
        {
            if(_useIA)
            {
                return new AIInputAdapter(_ship);
            }
            if(_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }
    }
}


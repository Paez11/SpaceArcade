using System;
using Inputs;
using Input = Inputs.Input;
using Ships.CheckLimits;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useIA;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joybutton;
        [SerializeField] private ShipMediator _ship;

        private void Awake() 
        {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
        }

        private CheckLimit GetCheckLimitsStrategy()
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
                return new JoystickInputAdapter(_joystick, _joybutton);
            }
            Destroy(_joystick.gameObject);
            Destroy(_joybutton.gameObject);
            return new UnityInputAdapter();
        }
    }
}


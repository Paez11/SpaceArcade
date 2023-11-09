using UnityEngine;

namespace ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake() 
        {
            _ship.Configure(GetInput());
        }

        private Input GetInput()
        {
            if(_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }
            Destroy(_joystick.gameObject);
            return new UnityInputAdapter();
        }
    }
}


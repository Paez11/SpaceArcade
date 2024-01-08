using Inputs;
using Ships.CheckLimits;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }

        public enum CheckLimitTypes
        {
            InitialPosition,
            ViewPort
        }
        private ShipMediator _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private Inputs.Input _input;
        private CheckLimits.CheckLimit _checkLimits;
        private ShipToSpawnConfiguration _shipConfiguration;
        private InputMode _inputMode;
        private Joystick _joyStick;
        private JoyButton _joyButton;
        private CheckLimitTypes _checkLimitType;

        public ShipBuilder FromPrefab(ShipMediator prefab)
        {
            _prefab = prefab;
            return this;
        }
        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }
        public ShipBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }
        public ShipBuilder WithInput(Inputs.Input input)
        {
            _input = input;
            return this;
        }
        public ShipBuilder WithCheckLimit(CheckLimits.CheckLimit checklimits)
        {
            _checkLimits = checklimits;
            return this;
        }
        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            _shipConfiguration = shipConfiguration;
            return this;
        }
        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            _inputMode = inputMode;
            return this;
        }
        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            _joyStick = joystick;
            _joyButton = joyButton;
            return this;
        }

        public ShipBuilder WithCheckLimitTypes(CheckLimitTypes type)
        {
            _checkLimitType = type;
            return this;
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(_prefab, _position, _rotation);
            var shipConfiguration = new shipConfiguration(GetInput(ship), 
                GetCheckLimits(ship),
                _shipConfiguration.Speed,
                _shipConfiguration.FireRate,
                _shipConfiguration.DefaultProjectileId);
            ship.Configure(shipConfiguration);
            return ship;
        }

        private CheckLimit GetCheckLimits(ShipMediator ship)
        {
            if(_checkLimits != null)
                return _checkLimits;
            
            switch (_checkLimitType)
            {
                case CheckLimitTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitTypes.ViewPort:
                    return new ViewportCheckLimits(ship.transform, Camera.main);
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
            
        }

        private Inputs.Input GetInput(ShipMediator shipMediator)
        {
            if(_input != null)
                return _input;

            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(_joyStick);
                    Assert.IsNotNull(_joyButton);
                    return new JoystickInputAdapter(_joyStick, _joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}


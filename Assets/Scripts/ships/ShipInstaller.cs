using System;
using Inputs;
using Input = Inputs.Input;
using Ships.CheckLimits;
using UnityEngine;
using Ships.Enemies;
using Ships.Common;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useIA;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joybutton;
        [SerializeField] private ShipMediator _ship;

        [SerializeField] private ShipToSpawnConfiguration _shipConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;

        private ShipBuilder _shipBuilder;
        private ShipMediator _userShip;

        private void Awake() 
        {
            var shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            _shipBuilder = shipFactory.Create(_shipConfiguration.ShipId.Value)
            .WithTeam(Teams.Ally)
            .WithConfiguration(_shipConfiguration);
            
            SetInput(_shipBuilder);
            SetCheckLimitsStrategy(_shipBuilder);
        }

        public void SpawnUserShip()
        {
            _userShip = _shipBuilder.Build();
        }

        public void DestroyUserShip()
        {
            Destroy(_userShip.gameObject);
        }

        private void SetCheckLimitsStrategy(ShipBuilder shipBuilder)
        {
            shipBuilder.WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.InitialPosition);
            return;
            /*
            if(_useIA)
            {
                //shipBuilder.WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.InitialPosition);
                return;
            }
            shipBuilder.WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.ViewPort);
            */
        }

        private void SetInput(ShipBuilder shipBuilder)
        {
            if(_useIA)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai);
                return;
            }
            if(_useJoystick)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Joystick);
                shipBuilder.WithJoysticks(_joystick, _joybutton);
                return;
            }

            shipBuilder.WithInputMode(ShipBuilder.InputMode.Unity);

            Destroy(_joystick.gameObject);
            Destroy(_joybutton.gameObject);
        }
    }
}


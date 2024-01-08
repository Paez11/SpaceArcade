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

        private void Awake() 
        {
            var shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            var shipBuilder = shipFactory.Create(_shipConfiguration.ShipId.Value).WithConfiguration(_shipConfiguration);
            
            SetInput(shipBuilder);
            SetCheckLimitsStrategy(shipBuilder);
            shipBuilder.Build();
        }

        private void SetCheckLimitsStrategy(ShipBuilder shipBuilder)
        {
            if(_useIA)
            {
                shipBuilder.WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.InitialPosition);
                return;
            }
            shipBuilder.WithCheckLimitTypes(ShipBuilder.CheckLimitTypes.ViewPort);
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


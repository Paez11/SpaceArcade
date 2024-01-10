using Battle;
using Ships;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;

        [SerializeField] private GameFacade _gameFacade;
        private void Awake() 
        {
            _startBattleButton.onClick.AddListener(StartBattle);   
            _stopBattleButton.onClick.AddListener(StopBattle);   
        }

        private void StartBattle()
        {
            _gameFacade.StartBattle();
        }

        private void StopBattle()
        {
            _gameFacade.StopBattle();
        }
    }
}


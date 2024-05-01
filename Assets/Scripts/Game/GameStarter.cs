using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform _playerPoint;
        [Inject] private PlayerObject _playerObject;
        [Inject] private GameState _gameState;
        [Inject] private GameScreen _gameScreen;
        [Inject] private GameData _gameData;

        public void StartGame()
        {
            _gameData.ResetCount();
            _gameState.ChangeGameState(State.Game);
            _gameScreen.Open();
            _playerObject.transform.position = _playerPoint.position;
            _playerObject.Enable();
        }
    }
}
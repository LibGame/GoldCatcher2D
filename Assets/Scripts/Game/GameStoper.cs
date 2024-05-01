using Assets.Scripts.Data;
using Assets.Scripts.Generation;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    public class GameStoper : MonoBehaviour
    {
        [Inject] private PlayerObject _playerObject;
        [Inject] private GameState _gameState;
        [Inject] private ItemSpawner _itemSpawner;
        [Inject] private GameOverPanel _gameOverPanel;
        [Inject] private GameScreen _gameScreen;
        [Inject] private GameSettings _gameSettings;

        private Coroutine _stopGameCoroutine;

        public void CallStopGame()
        {
            _gameState.ChangeGameState(State.Pause);
            _itemSpawner.StopSpawn();
            _stopGameCoroutine = StartCoroutine(StopGameAfterSconds());
        }

        public IEnumerator StopGameAfterSconds()
        {
            yield return new WaitForSeconds(_gameSettings.TimeToEndGame);
            _gameOverPanel.Open();
            _gameScreen.Close();
            _playerObject.Disable();
        }
    }
}
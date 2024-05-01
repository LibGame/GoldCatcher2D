using Assets.Scripts.Data;
using Assets.Scripts.Game;
using System.Collections;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace Assets.Scripts.UI
{
    public class LoadingScreen : Screen
    {
        [SerializeField] private Transform _loadingIcon;
        [Inject] private GameSettings _gameSettings;
        [Inject] private GameState _gameState;

        private void Start()
        {
            _gameState.ChangeGameState(State.Loading);
            Open();
            StartCoroutine(EnterInGame());
        }

        private void Update()
        {
            if(_gameState.CurrentGameState == State.Loading)
            {
                _loadingIcon.Rotate(new Vector3(0,0,0.5f));
            }
        }

        private IEnumerator EnterInGame()
        {
            yield return new WaitForSeconds(_gameSettings.TimeToLoadingGame);
            _gameState.ChangeGameState(State.Menu);
            Close();
        }
    }
}
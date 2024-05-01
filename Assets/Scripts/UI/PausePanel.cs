using Assets.Scripts.Game;
using Assets.Scripts.MusicAndSounds;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class PausePanel : Panel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _openButton;
        [Inject] private GameState _gameState;
        [Inject] private Sound _sound;

        private void Awake()
        {
            _openButton.onClick.AddListener(Open);
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _openButton.onClick.RemoveListener(Open);
            _closeButton.onClick.RemoveListener(Close);
        }

        public override void Open()
        {
            _sound.PlayButtonSoundClick();
            base.Open();
            _gameState.ChangeGameState(State.Pause);
        }

        public override void Close()
        {
            _sound.PlayButtonSoundClick();
            base.Close();
            _gameState.ChangeGameState(State.Game);
        }
    }
}
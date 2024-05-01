using Assets.Scripts.Game;
using Assets.Scripts.MusicAndSounds;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class GameOverPanel : Panel
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private TMP_Text _endlesScoreText;

        [Inject] private MenuScreen _menuScreen;
        [Inject] private GameScreen _gameScreen;
        [Inject] private GameStarter _gameStarter;
        [Inject] private GameData _gameData;
        [Inject] private Sound _sound;

        private void Awake()
        {
            _menuButton.onClick.AddListener(OpenMenu);
            _retryButton.onClick.AddListener(Retry);
        }

        private void OnDestroy()
        {
            _menuButton.onClick.RemoveListener(OpenMenu);
            _retryButton.onClick.RemoveListener(Retry);
        }

        public override void Open()
        {
            _endlesScoreText.text = _gameData.CoinAmount.ToString();
            base.Open();
        }

        public void OpenMenu()
        {
            _sound.PlayButtonSoundClick();
            Close();
            _gameScreen.Close();
            _menuScreen.Open();
        }

        public void Retry()
        {
            _sound.PlayButtonSoundClick();
            _gameStarter.StartGame();
            Close();
        }
    }
}
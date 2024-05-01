using Assets.Scripts.Game;
using Assets.Scripts.MusicAndSounds;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [Inject] private SettingsPanel _settingsPanel;
        [Inject] private Sound _sound;
        [Inject] private GameStarter _gameStarter;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(StartGame);
            _settingsButton.onClick.AddListener(OpenSettings);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(StartGame);
            _settingsButton.onClick.RemoveListener(OpenSettings);
        }

        public void StartGame()
        {
            _sound.PlayButtonSoundClick();
            _gameStarter.StartGame();
            Close();
        }

        private void OpenSettings()
        {
            _sound.PlayButtonSoundClick();
            _settingsPanel.Open();
            Close();
        }
    }
}
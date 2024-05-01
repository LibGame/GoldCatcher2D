using Assets.Scripts.Data;
using Assets.Scripts.MusicAndSounds;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class SettingsPanel : Panel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider[] _soundSliders;
        [SerializeField] private Slider[] _musicSliders;
        [Inject] private Sound _sound;
        [Inject] private GameSettings _gameSettings;
        [Inject] private MenuScreen _menuScreen;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);

            foreach(var soundSlider in _soundSliders)
            {
                soundSlider.OnValueChanged += OnChangeSoundSlider;

                InitSliderSettings("SoundMode", (value) => {
                    _gameSettings.SetSoundMode(value);
                    soundSlider.SetupOnModeWithoutEvent(value);
                });
            }

            foreach (var musicSlider in _musicSliders)
            {
                musicSlider.OnValueChanged += OnChangeMusicSlider;

                InitSliderSettings("MusicMode", (value) => {
                    _gameSettings.SetMusicMode(value);
                    musicSlider.SetupOnModeWithoutEvent(value);
                });
            }
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Close);

            foreach (var soundSlider in _soundSliders)
            {
                soundSlider.OnValueChanged -= OnChangeSoundSlider;
            }

            foreach (var musicSlider in _musicSliders)
            {
                musicSlider.OnValueChanged -= OnChangeMusicSlider;
            }
        }

        public override void Close()
        {
            _sound.PlayButtonSoundClick();
            _menuScreen.Open();
            base.Close();
        }

        private void InitSliderSettings(string key , Action<bool> action)
        {
            if (PlayerPrefs.HasKey(key))
            {
                if (PlayerPrefs.GetInt(key) == 1)
                {
                    action?.Invoke(true);
                }
                else
                {
                    action?.Invoke(false);
                }
            }
        }

        private void OnChangeSoundSlider(bool isMode)
        {
            _gameSettings.SetSoundMode(isMode);
            _sound.PlayButtonSoundClick();
            PlayerPrefs.SetInt("SoundMode", isMode ? 1 : 0);
            foreach (var item in _soundSliders)
            {
                item.SetupOnModeWithoutEvent(isMode);
            }
        }

        private void OnChangeMusicSlider(bool isMode)
        {
            _gameSettings.SetMusicMode(isMode);
            _sound.PlayButtonSoundClick();
            PlayerPrefs.SetInt("MusicMode", isMode ? 1 : 0);
            foreach (var item in _musicSliders)
            {
                item.SetupOnModeWithoutEvent(isMode);
            }
        }
    }
}
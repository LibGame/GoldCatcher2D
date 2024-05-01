using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MusicAndSounds
{
    public class Sound : MonoBehaviour
    {
        [SerializeField] private AudioClip _buttonSoundClick;
        [SerializeField] private AudioClip _coinTakeSound;
        [SerializeField] private AudioClip _explosionSound;
        [SerializeField] private AudioSource _audioSource;
        [Inject] private GameSettings _gameSettings;

        public void PlayButtonSoundClick()
        {
            if (!_gameSettings.IsSound)
                return;
            _audioSource.clip = _buttonSoundClick;
            _audioSource.Play();
        }

        public void PlayCoinTakeSound()
        {
            if (!_gameSettings.IsSound)
                return;
            _audioSource.clip = _coinTakeSound;
            _audioSource.Play();
        }

        public void PlayExplosionSound()
        {
            if (!_gameSettings.IsSound)
                return;
            _audioSource.clip = _explosionSound;
            _audioSource.Play();
        }
    }
}
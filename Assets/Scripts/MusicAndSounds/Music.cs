using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MusicAndSounds
{
    public class Music : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [Inject] private GameSettings _gameSettings;

        private void Awake()
        {
            _gameSettings.OnChangeMusic += UpdateMusicState;
        }

        private void Start()
        {
            UpdateMusicState(_gameSettings.IsMusic);
        }

        private void OnDestroy()
        {
            _gameSettings.OnChangeMusic -= UpdateMusicState;
        }

        public void UpdateMusicState(bool mode)
        {
            if(mode)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }
        }
    }
}
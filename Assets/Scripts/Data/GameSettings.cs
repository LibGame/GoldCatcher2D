using Assets.Scripts.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Range(0f, 5f)][SerializeField] private float _timeToLoadingGame = 1f;
        [Range(0f, 5f)][SerializeField] private float _timeToEndGame = 1f;
        [Range(0f, 100f)][SerializeField] private float _bombMoveSpeed = 1f;
        [Range(0f, 100f)][SerializeField] private float _coinMoveSpeed = 1f;
        [SerializeField] private float _overallSpawnRate = 1f;
        [SerializeField] private int _maxObjectsPerSpawn = 1;

        [SerializeField] private ItemData[] _itemDatas;

        [field: SerializeField] public bool IsSound { get; private set; }
        [field: SerializeField] public bool IsMusic { get; private set; }
        public float TimeToEndGame => _timeToEndGame;
        public float BombMoveSpeed => _bombMoveSpeed;
        public float CoinMoveSpeed => _coinMoveSpeed;
        public float OverallSpawnRate => _overallSpawnRate;
        public int MaxObjectsPerSpanw => _maxObjectsPerSpawn;
        public float TimeToLoadingGame => _timeToLoadingGame;
        public IReadOnlyList<ItemData> ItemDatas => _itemDatas;

        public event Action<bool> OnChangeSound;
        public event Action<bool> OnChangeMusic;

        public void SetSoundMode(bool soundMode)
        {
            IsSound = soundMode;
            OnChangeSound?.Invoke(IsSound);
        }

        public void SetMusicMode(bool musicMode)
        {
            IsMusic = musicMode;
            OnChangeMusic?.Invoke(IsMusic);
        }
    }
}
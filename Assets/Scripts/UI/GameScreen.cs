using Assets.Scripts.Game;
using Assets.Scripts.MusicAndSounds;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    public class GameScreen : Screen
    {
        [SerializeField] private TMP_Text _coinScore;
        [Inject] private GameData _gameData;

        private void Awake()
        {
            _gameData.OnChangeCoinAmount += ChangeCountAmount;
        }

        private void OnDestroy()
        {
            _gameData.OnChangeCoinAmount -= ChangeCountAmount;
        }

        public void ChangeCountAmount(int amount)
        {
            _coinScore.text = amount.ToString();
        }

    }
}
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameData
    {
        public event Action<int> OnChangeCoinAmount;

        private int _cointAmount;

        public int CoinAmount
        {
            get
            {
                if(_cointAmount <= 0)
                    return 0;
                return _cointAmount;
            }
        }

        public void ResetCount()
        {
            _cointAmount = 0;
            OnChangeCoinAmount?.Invoke(CoinAmount);
        }

        public void IncreaseAmount()
        {
            _cointAmount++;
            OnChangeCoinAmount?.Invoke(CoinAmount);
        }
    }
}
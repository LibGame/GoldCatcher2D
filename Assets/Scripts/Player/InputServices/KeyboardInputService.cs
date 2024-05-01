using Assets.Scripts.Data;
using Assets.Scripts.Game;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.InputServices
{
    public class KeyboardInputService : MonoBehaviour, IInputService
    {
        [Inject] private PlayerData _playerData;
        [Inject] private GameState _gameState;

        public event Action LeftButtonHold;
        public event Action RightButtonHold;
        public event Action LeftButtonUp;
        public event Action RightButtonUp;

        private bool _isActive;

        public void Init()
        {
            _isActive = true;
        }

        private void Update()
        {
            if (!_isActive)
                return;

            if(_gameState.CurrentGameState == State.Game)
            {
                if (Input.GetKey(_playerData.LeftButtonKeyCode))
                {
                    LeftButtonHold?.Invoke();
                }else if (Input.GetKeyUp(_playerData.LeftButtonKeyCode))
                {
                    LeftButtonUp?.Invoke();
                }
                if (Input.GetKey(_playerData.RightButtonKeyCode))
                {
                    RightButtonHold?.Invoke();
                }
                else if (Input.GetKeyUp(_playerData.RightButtonKeyCode))
                {
                    RightButtonUp?.Invoke();
                }
            }
        }
    }
}
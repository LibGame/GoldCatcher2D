using Assets.Scripts.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player.InputServices
{
    public class UIButtonsInputService : MonoBehaviour, IInputService
    {
        [SerializeField] private List<GameObject> _inputServiceObjects;
        [SerializeField] private ButtonHold _rightButton;
        [SerializeField] private ButtonHold _leftButton;

        public event Action LeftButtonHold;
        public event Action RightButtonHold;
        public event Action LeftButtonUp;
        public event Action RightButtonUp;

        private void OnEnable()
        {
            if(_rightButton != null)
                _rightButton.AddAction(new UnityAction(OnRightButtonHold));
            if (_leftButton != null)
                _leftButton.AddAction(new UnityAction(OnLeftButtonHold));
        }

        private void OnDisable()
        {
            if (_rightButton != null)
                _rightButton.RemoveAction(new UnityAction(OnRightButtonHold));
            if (_leftButton != null)
                _leftButton.RemoveAction(new UnityAction(OnLeftButtonHold));
        }

        public void Init()
        {
            _inputServiceObjects.ForEach(item =>
            {
                item.SetActive(true);
            });
        }

        private void OnRightButtonHold()
        {
            RightButtonHold?.Invoke();
        }

        private void OnLeftButtonHold()
        {
            LeftButtonHold?.Invoke();
        }
    }
}
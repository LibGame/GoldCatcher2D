using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Utility
{
    public class ButtonHold : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UnityEvent _hold;

        private bool _isPressed;

        public void AddAction(UnityAction action)
        {
            _hold?.AddListener(action);
        }

        public void RemoveAction(UnityAction action)
        {
            _hold?.RemoveListener(action);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                _hold?.Invoke();
            }
        }
    }
}
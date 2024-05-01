using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Slider : MonoBehaviour , IPointerClickHandler
    {
        [SerializeField] private Image _slider;
        [SerializeField] private Sprite _onSlider;
        [SerializeField] private Sprite _offSlider;

        public bool IsOn { get; private set; }

        public event Action<bool> OnValueChanged;

        public void OnPointerClick(PointerEventData eventData)
        {
            IsOn = !IsOn;
            UpdateView();
        }

        public void SetupOnMode(bool isOn)
        {
            IsOn = isOn;
            UpdateView();
        }
        public void SetupOnModeWithoutEvent(bool isOn)
        {
            IsOn = isOn;
            UpdateView(false);
        }

        private void UpdateView(bool callEvent = true)
        {
            if(IsOn)
                _slider.sprite = _onSlider;
            else
                _slider.sprite = _offSlider;

            if(callEvent)
                OnValueChanged?.Invoke(IsOn);
        }
    }
}
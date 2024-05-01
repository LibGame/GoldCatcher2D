using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.InputServices
{
    public interface IInputService
    {
        public event Action LeftButtonHold;
        public event Action RightButtonHold;
        public event Action LeftButtonUp;
        public event Action RightButtonUp;
        void Init();
    }
}
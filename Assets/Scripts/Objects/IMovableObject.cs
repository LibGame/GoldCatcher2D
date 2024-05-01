using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public interface IMovableObject 
    {
        bool IsActive { get; }
        void Move();
        void Stop();
    }
}
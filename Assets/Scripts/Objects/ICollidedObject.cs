using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public interface ICollidedObject
    {
        bool IsActive { get; }
        public event Action<GameObject , Object> Collided;
    }
}
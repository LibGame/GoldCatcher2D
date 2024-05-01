using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public interface IInitializable
    {
        void Initialize<T>(IEnumerable<T> item);
    }
}
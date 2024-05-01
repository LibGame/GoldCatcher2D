using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public interface ISpawnableObject
    {
        float SpawnChance { get;}
        Object Object { get;}
        void SetSpawnChance(float spawnChance);
    }
}
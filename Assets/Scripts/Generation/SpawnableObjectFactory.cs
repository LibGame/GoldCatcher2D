using Assets.Scripts.Data;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Generation
{
    public class SpawnableObjectFactory 
    {
        [Inject] private DiContainer _container;

        public bool TryCreateSpawnableObject<T>(GameObject prefab , float spawnChanse , out T objectType) where T : ISpawnableObject
        {

            GameObject createdObject = _container.InstantiatePrefab(prefab);
            if (createdObject.TryGetComponent(out objectType))
            {
                objectType.SetSpawnChance(spawnChanse);
                return true;
            }
            objectType = default;
            return false;
        }

    }
}
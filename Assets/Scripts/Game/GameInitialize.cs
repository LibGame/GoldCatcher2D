using Assets.Scripts.Data;
using Assets.Scripts.Generation;
using Assets.Scripts.MoveObjects;
using Assets.Scripts.Objects;
using Assets.Scripts.ObjectServices;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;
using Object = Assets.Scripts.Objects.Object;

namespace Assets.Scripts.Game
{
    public class GameInitialize : MonoBehaviour
    {
        [Inject] private MoveObjectService _moveObjectService;
        [Inject] private ColidedService _colidedService;
        [Inject] private ItemSpawner _itemSpawner;
        [Inject] private SpawnableObjectFactory _objectFactory;
        [Inject] private GameSettings _gameSettings;

        private void Awake()
        {
            List<ISpawnableObject> spawnables = CreateSpawnableObjects();
            List<IMovableObject> movableObjects = CastToType<IMovableObject,Object>(spawnables.Select(x => x.Object));
            List<ICollidedObject> colidedObjects = CastToType<ICollidedObject, Object>(spawnables.Select(x => x.Object));

            _moveObjectService.Initialize(movableObjects);
            _colidedService.Initialize(colidedObjects);
            _itemSpawner.Initialize(colidedObjects);
        }

        private List<T> CastToType<T, K>(IEnumerable<K> objects) where K : Object
        {
            List<T> result = new List<T>();
            foreach(var item in  objects)
            {
                if (item.gameObject.TryGetComponent(out T component))
                    result.Add(component);
            }
            return result;
        }

        private List<ISpawnableObject> CreateSpawnableObjects()
        {
            List<ISpawnableObject> spawnableObjects = new List<ISpawnableObject>();

            foreach (var data in _gameSettings.ItemDatas)
            {
                for(int i = 0; i < data.PoolCount; i++)
                {
                    if (_objectFactory.TryCreateSpawnableObject(data.ObjectPrefab,
                            data.SpawnChance, out ISpawnableObject spawnableObject))
                    {
                        spawnableObjects.Add(spawnableObject);
                    }
                }
            }

            return spawnableObjects; ;
        }

    }
}
using System;
using System.Collections;
using UnityEngine;
using Object = Assets.Scripts.Objects.Object;

namespace Assets.Scripts.Generation
{
    [Serializable]
    public struct ItemData
    {
        [SerializeField][Range(0f, 1f)] private float _spawnChance;

        [SerializeField] private GameObject _objectPrefab;
        [field: SerializeField] public int PoolCount { get; private set; }
        public float SpawnChance => _spawnChance;
        public GameObject ObjectPrefab => _objectPrefab;
    }
}
using Assets.Scripts.Data;
using Assets.Scripts.Game;
using Assets.Scripts.MoveObjects;
using Assets.Scripts.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Generation
{
    public class ItemSpawner : MonoBehaviour , Game.IInitializable
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [Inject] private GameSettings _gameSettings;
        [Inject] private GameState _gameState;
        [Inject] private SpawnableObjectFactory _spawnableObjectFactory;
        [Inject] private MoveObjectService _moveObjectService;

        private List<ISpawnableObject> _spawnedObjectsPool = new List<ISpawnableObject>();

        private float _nextSpawnTime = 0f;

        public void Initialize<ISpawnableObject>(IEnumerable<ISpawnableObject> spawnedObjectsPool)
        {
            foreach(var spawnableObject in spawnedObjectsPool)
            {
                _spawnedObjectsPool.Add((Objects.ISpawnableObject)spawnableObject);
            }
            _spawnedObjectsPool.ForEach(obj => obj.Object.Disable());
        }

        public void StopSpawn()
        {
            foreach(var item in _spawnedObjectsPool)
            {
                item.Object.Disable();
            }
        }

        private void Update()
        {
            if(_gameState.CurrentGameState == State.Game)
            {
                if (Time.time >= _nextSpawnTime)
                {
                    SpawnObjects();
                    _nextSpawnTime = Time.time + 1f / _gameSettings.OverallSpawnRate;
                }
            }
        }

        private void SpawnObjects()
        {
            int objectsToSpawn = Random.Range(1, _gameSettings.MaxObjectsPerSpanw + 1);

            for (int i = 0; i < objectsToSpawn; i++)
            {
                Objects.Object spawnedObject = SelectObjectToSpawn();
                spawnedObject.Enable();
                spawnedObject.transform.position = RandomPosition();
            }
        }

        private Objects.Object SelectObjectToSpawn()
        {
            float total = 0;
            List<ISpawnableObject> spawnableObjects = _spawnedObjectsPool.Where(item => !item.Object.gameObject.activeSelf).ToList();
            float[] spawnChances = spawnableObjects.Select(x => x.SpawnChance).ToArray();

            total = spawnChances.Sum();

            float randomPoint = Random.value * total;

            for (int i = 0; i < spawnChances.Length; i++)
            {
                if (randomPoint < spawnChances[i])
                    return spawnableObjects[i].Object;
                else
                    randomPoint -= spawnChances[i];
            }
            return spawnableObjects[0].Object;
        }

        private Vector3 RandomPosition()
        {           
            if(_spawnPoints.Count == 0)
                return Vector3.zero;

            return _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        }
    }
}
using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Objects
{
    public class BombObject : Object, ISpawnableObject, IMovableObject , ICollidedObject
    {
        [SerializeField][Range(0f, 1f)] private float _spawnChance;
        [Inject] private GameSettings _gameSettings;
        public float SpawnChance => _spawnChance;
        public Object Object => this;
        public bool IsActive => gameObject.activeSelf;
        public event System.Action<GameObject, Object> Collided;

        public void Move()
        {
            MoveInDirection(Vector2.down * _gameSettings.BombMoveSpeed);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null && collision.transform != null)
            {
                Collided?.Invoke(collision.transform.gameObject, this);
            }
        }


        public void SetSpawnChance(float spawnChance)
        {
            _spawnChance = spawnChance;
        }

        public void Stop()
        {
            MoveInDirection(Vector2.zero);
        }
    }
}
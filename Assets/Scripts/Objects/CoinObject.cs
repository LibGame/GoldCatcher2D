using Assets.Scripts.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace Assets.Scripts.Objects
{
    public class CoinObject : Object, ISpawnableObject , IMovableObject, ICollidedObject
    {
        [SerializeField][Range(0f, 1f)] private float _spawnChance;
        [Inject] private GameSettings _gameSettings;
        public float SpawnChance => _spawnChance;
        public bool IsActive => gameObject.activeSelf;
        public Object Object => this;
        public event System.Action<GameObject, Object> Collided;

        public void Move()
        {
            MoveInDirection(Vector2.down * _gameSettings.CoinMoveSpeed);
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
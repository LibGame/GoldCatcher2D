using Assets.Scripts.Game;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MoveObjects
{
    public class MoveObjectService : MonoBehaviour , Game.IInitializable
    {
        [Inject] private GameState _gameState;

        private List<IMovableObject> _movableObjects = new List<IMovableObject>();

        private void Start()
        {
            _gameState.GameStateChanged += OnChageGameState;
        }

        public void Initialize<IMovableObject>(IEnumerable<IMovableObject> item)
        {
            foreach (var spawnableObject in item)
            {
                _movableObjects.Add((Objects.IMovableObject)spawnableObject);
            }
        }

        private void OnChageGameState(State state)
        {
            if(state == State.Pause)
            {
                _movableObjects.ForEach(item =>
                {
                    if (item.IsActive)
                    {
                        item.Stop();
                    }
                });
            }
        }

        private void Update()
        {
            if(_gameState.CurrentGameState == State.Game)
            {
                _movableObjects.ForEach(item =>
                {
                    if(item.IsActive)
                    {
                        item.Move();
                    }
                });
            }
        }
    }
}
using Assets.Scripts.Game;
using Assets.Scripts.MusicAndSounds;
using Assets.Scripts.Objects;
using Assets.Scripts.Player;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = Assets.Scripts.Objects.Object;

namespace Assets.Scripts.ObjectServices
{
    public class ColidedService : MonoBehaviour , Game.IInitializable
    {
        [Inject] private GameData _gameData;
        [Inject] private GameStoper _gameStoper;
        [Inject] private PlayerObject _playerObject;
        [Inject] private Sound _sound;

        private List<ICollidedObject> _movableObjects = new List<ICollidedObject>();

        public void Initialize<ICollidedObject>(IEnumerable<ICollidedObject> item)
        {
            foreach (var spawnableObject in item)
            {
                _movableObjects.Add((Objects.ICollidedObject)spawnableObject);
            }

            _movableObjects.ForEach(item => {
                item.Collided += OnColided;
            });
        }

        private void DistrebuteCollideWithPlayerHanlers(Object objectItem)
        {
            if(objectItem is CoinObject coinObject)
            {
                _sound.PlayCoinTakeSound();
                _playerObject.SetupCoinsBagSprite();
                _gameData.IncreaseAmount();
            }else if(objectItem is BombObject bombObject)
            {
                _sound.PlayExplosionSound();
                _playerObject.Explosion();
                _gameStoper.CallStopGame();
            }
        }

        private void OnColided(GameObject gameObject, Object objectItem)
        {
            if(gameObject.TryGetComponent(out PlayerObject playerObject))
            {
                DistrebuteCollideWithPlayerHanlers(objectItem);
                objectItem.Disable();
            }
            else if(gameObject.TryGetComponent(out OutScreenPlane outScreenPlane))
            {
                objectItem.Disable();
            }
        }

    }
}
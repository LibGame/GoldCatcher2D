using Assets.Scripts.Data;
using Assets.Scripts.Game;
using Assets.Scripts.Generation;
using Assets.Scripts.MoveObjects;
using Assets.Scripts.MusicAndSounds;
using Assets.Scripts.ObjectServices;
using Assets.Scripts.Player;
using Assets.Scripts.Player.InputServices;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Music _music;
        [SerializeField] private Sound _sound;
        [SerializeField] private GameStoper _gameStoper;
        [SerializeField] private PlayerObject _playerObject;
        [SerializeField] private GameInitialize _gameInitialize;
        [SerializeField] private GameStarter _gameStarter;
        [SerializeField] private MoveObjectService _moveObjectService;
        [SerializeField] private ColidedService _colidedService;
        [SerializeField] private ItemSpawner _itemSpawner;
        [SerializeField] private KeyboardInputService _keyboardInputService;
        [SerializeField] private UIButtonsInputService _uiButtonsInputService;
        [SerializeField] private PlayerMoveService _playerMoveService;
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private PlayerData _playerData;

        public override void InstallBindings()
        {
            Container.Bind<Music>().FromInstance(_music).AsSingle();
            Container.Bind<Sound>().FromInstance(_sound).AsSingle();
            Container.Bind<GameInitialize>().FromInstance(_gameInitialize).AsSingle();
            Container.Bind<GameData>().FromNew().AsSingle();
            Container.Bind<SpawnableObjectFactory>().FromNew().AsSingle();
            Container.Bind<GameStoper>().FromInstance(_gameStoper).AsSingle();
            Container.Bind<PlayerObject>().FromInstance(_playerObject).AsSingle();
            Container.Bind<GameStarter>().FromInstance(_gameStarter).AsSingle();
            Container.Bind<MoveObjectService>().FromInstance(_moveObjectService).AsSingle();
            Container.Bind<ColidedService>().FromInstance(_colidedService).AsSingle();
            Container.Bind<GameState>().FromNew().AsSingle();
            Container.Bind<ItemSpawner>().FromInstance(_itemSpawner).AsSingle();
            Container.Bind<KeyboardInputService>().FromInstance(_keyboardInputService).AsSingle();
            Container.Bind<UIButtonsInputService>().FromInstance(_uiButtonsInputService).AsSingle();
            Container.Bind<PlayerMoveService>().FromInstance(_playerMoveService).AsSingle();
            Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();
            Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
        }

    }
}
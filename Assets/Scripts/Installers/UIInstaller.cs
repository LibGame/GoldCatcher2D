using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private MenuScreen _menuScene;
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private GameScreen _gameScreen;
        [SerializeField] private GameOverPanel _gameOverPanel;

        public override void InstallBindings()
        {
            Container.Bind<PausePanel>().FromInstance(_pausePanel).AsSingle();
            Container.Bind<GameOverPanel>().FromInstance(_gameOverPanel).AsSingle();
            Container.Bind<MenuScreen>().FromInstance(_menuScene).AsSingle();
            Container.Bind<SettingsPanel>().FromInstance(_settingsPanel).AsSingle();
            Container.Bind<GameScreen>().FromInstance(_gameScreen).AsSingle();
        }
    }
}
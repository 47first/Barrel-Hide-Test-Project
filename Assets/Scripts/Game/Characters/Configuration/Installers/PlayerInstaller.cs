using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Player;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade.Impl;
using BarrelHide.Game.Characters.Input.Actualizers;
using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Configuration.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerOptions _options;
        [SerializeField] private PlayerView _view;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlayerFacade>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerOptions>()
                .FromInstance(_options);

            Container.BindInstance(_view);

            // Input
            Container
                .BindInterfacesAndSelfTo<PlayerInput>()
                .AsSingle();
            Container
                .BindInterfacesTo<DevicePlayerInputActualizer>()
                .AsSingle();

            // Controllers
            Container
                .Bind<CharacterController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<CharacterTransformController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<PlayerVisibilityController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<PlayerViewController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();
        }
    }
}

using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Player;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade.Impl;
using BarrelHide.Game.Characters.Input.Actualizers;
using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Configuration.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header(HeaderConst.References)]
        [SerializeField] private PlayerOptions _options;
        [SerializeField] private PlayerView _view;
        [SerializeField] private GameObject _presenter;

        public override void InstallBindings()
        {
            // Facade
            Container
                .BindInterfacesTo<PlayerFacade>()
                .AsSingle();

            // Options
            Container
                .BindInterfacesAndSelfTo<PlayerOptions>()
                .FromInstance(_options);

            // View
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
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<CharacterTransformController>()
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<PlayerVisibilityController>()
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<PlayerViewController>()
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
        }
    }
}

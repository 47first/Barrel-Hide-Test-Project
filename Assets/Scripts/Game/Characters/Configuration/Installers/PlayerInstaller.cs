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

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerOptions>()
                .FromInstance(_options);

            Container
                .BindInterfacesTo<PlayerFacade>()
                .AsSingle();

            Container
                .Bind<PlayerView>()
                .FromComponentInChildren()
                .AsSingle()
                .NonLazy();

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
                .FromNewComponentOnRoot()
                .AsSingle()
                .NonLazy();
            Container
                .Bind<PlayerViewController>()
                .FromNewComponentOnRoot()
                .AsSingle()
                .NonLazy();
        }
    }
}

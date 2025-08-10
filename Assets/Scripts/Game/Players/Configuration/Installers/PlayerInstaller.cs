using BarrelHide.Game.Players.Components;
using BarrelHide.Game.Players.Facade;
using BarrelHide.Game.Players.Facade.Impl;
using BarrelHide.Game.Players.Input.Impl;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Configuration.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerFacade>().To<PlayerFacade>().AsSingle();

            Container
                .BindInterfacesTo<DevicePlayerInput>()
                .AsSingle();

            Container
                .Bind<CharacterController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerTransformController>()
                .FromNewComponentOnRoot()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerViewController>()
                .FromNewComponentOnRoot()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerView>()
                .FromComponentInChildren()
                .AsSingle()
                .NonLazy();
        }
    }
}

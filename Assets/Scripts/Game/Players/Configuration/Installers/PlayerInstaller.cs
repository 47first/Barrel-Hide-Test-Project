using BarrelHide.Game.Players.Components;
using BarrelHide.Game.Players.Input.Impl;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Configuration.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<DevicePlayerInput>()
                .AsSingle();

            Container
                .Bind<CharacterController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerMovementController>()
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

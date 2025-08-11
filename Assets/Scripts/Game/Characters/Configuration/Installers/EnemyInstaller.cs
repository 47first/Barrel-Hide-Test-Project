using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade.Impl;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Configuration.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyOptions _options;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyOptions>()
                .FromInstance(_options);

            Container
                .BindInterfacesTo<EnemyFacade>()
                .AsSingle();

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
        }
    }
}

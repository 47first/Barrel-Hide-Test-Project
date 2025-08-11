using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Enemy;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade.Impl;
using BarrelHide.Game.Characters.Input.Actualizers;
using BarrelHide.Game.Characters.Input.Models;
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
                .BindInterfacesTo<EnemyFacade>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<EnemyOptions>()
                .FromInstance(_options);

            // Input
            Container
                .BindInterfacesAndSelfTo<EnemyInput>()
                .AsSingle();
            Container
                .BindInterfacesTo<AIEnemyInputActualizer>()
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
                .Bind<EnemyAIController>()
                .FromComponentOnRoot()
                .AsSingle()
                .NonLazy();
        }
    }
}

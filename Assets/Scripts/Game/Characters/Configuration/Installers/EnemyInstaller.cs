using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Enemy;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade.Impl;
using BarrelHide.Game.Characters.Input.Actualizers;
using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Configuration.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyOptions _options;
        [SerializeField] private EnemyView _view;
        [SerializeField] private GameObject _presenter;

        public override void InstallBindings()
        {
            // Facade
            Container
                .BindInterfacesTo<EnemyFacade>()
                .AsSingle();

            // Options
            Container
                .BindInterfacesAndSelfTo<EnemyOptions>()
                .FromInstance(_options);

            // View
            Container.BindInstance(_view);

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
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<CharacterTransformController>()
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
            Container
                .Bind<EnemyAIController>()
                .FromComponentOn(_presenter)
                .AsSingle()
                .NonLazy();
        }
    }
}

using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Configuration.Options;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Flow.Components;
using BarrelHide.Game.Flow.Impl;
using BarrelHide.Game.Input;
using BarrelHide.Game.Observers;
using BarrelHide.Generated.InputActions;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Configuration.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header(HeaderConst.Options)]
        [SerializeField] private GameOptions _options;

        [Header(HeaderConst.References)]
        [SerializeField] private GameObjectContext _playerContext;
        [SerializeField] private GameObjectContext[] _enemyContexts;

        public override void InstallBindings()
        {
            // Options
            Container.BindInstance(_options.CameraOptions);
            Container.BindInstance(_options.GameFlowOptions);

            // Player Facade
            _playerContext.Install(Container);

            Container
                .Bind<IPlayerFacade>()
                .FromSubContainerResolve()
                .ByInstance(_playerContext.Container)
                .AsSingle();

            // Enemy Facades
            foreach (var enemyContext in _enemyContexts)
            {
                enemyContext.Install(Container);

                Container
                    .Bind<IEnemyFacade>()
                    .FromSubContainerResolve()
                    .ByInstance(enemyContext.Container)
                    .AsCached();
            }

            // Game Flow
            Container
                .BindInterfacesTo<GameFlowController>()
                .AsSingle();

            // Input
            Container
                .BindInterfacesAndSelfTo<GameInputActions>()
                .AsSingle();

            Container
                .BindInterfacesTo<GameInputActionsHandle>()
                .AsSingle()
                .NonLazy();

            // Triggers
            Container
                .Bind<FinishTrigger>()
                .FromComponentInHierarchy()
                .AsSingle();

            // Observers
            Container
                .BindInterfacesTo<FinishTriggerObserver>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesTo<PlayerDetectionObserver>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesTo<StartGameOnInputTrigger>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesTo<LoseOnTimeUpTrigger>()
                .AsSingle()
                .NonLazy();
        }
    }
}

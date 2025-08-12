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
        [SerializeField] private GameObjectContext _player;
        [SerializeField] private GameObjectContext[] _enemies;

        public override void InstallBindings()
        {
            // Options
            Container.BindInstance(_options.PlayerOptions);
            Container.BindInstance(_options.CameraOptions);

            _player.Install(Container);

            Container
                .Bind<IPlayerFacade>()
                .FromSubContainerResolve()
                .ByInstance(_player.Container)
                .AsSingle();

            foreach (var enemy in _enemies)
            {
                enemy.Install(Container);

                Container
                    .Bind<IEnemyFacade>()
                    .FromSubContainerResolve()
                    .ByInstance(enemy.Container)
                    .AsSingle();
            }

            Container
                .BindInterfacesTo<GameFlowController>()
                .AsSingle();

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
        }
    }
}

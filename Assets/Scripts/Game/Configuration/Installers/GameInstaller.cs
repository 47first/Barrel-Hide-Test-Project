using BarrelHide.Game.Configuration.Options;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Input;
using BarrelHide.Game.Players.Facade;
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

        public override void InstallBindings()
        {
            // Options
            Container.BindInstance(_options.PlayerOptions);

            Container
                .Bind<IPlayerFacade>()
                .FromSubContainerResolve()
                .ByInstance(_player.Container)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GameInputActions>()
                .AsSingle();

            Container
                .BindInterfacesTo<GameInputActionsHandle>()
                .AsSingle()
                .NonLazy();
        }
    }
}

using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Facade.Impl
{
    public class PlayerFacade : IPlayerFacade
    {
        public Vector3 Position { get; }

        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}

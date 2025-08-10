using BarrelHide.Game.Players.Components;
using UnityEngine;

namespace BarrelHide.Game.Players.Facade.Impl
{
    public class PlayerFacade : IPlayerFacade
    {
        private readonly PlayerTransformController _transformController;

        public PlayerFacade(PlayerTransformController transformController)
        {
            _transformController = transformController;
        }

        public Vector3 Position => _transformController.transform.position;
    }
}

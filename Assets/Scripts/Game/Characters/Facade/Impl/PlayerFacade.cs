using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Player;
using UnityEngine;

namespace BarrelHide.Game.Characters.Facade.Impl
{
    public class PlayerFacade : IPlayerFacade
    {
        private readonly CharacterTransformController _transformController;
        private readonly PlayerVisibilityController _visibilityController;
        private readonly CharacterController _characterController;

        public PlayerFacade(
            CharacterTransformController transformController,
            PlayerVisibilityController visibilityController,
            CharacterController characterController)
        {
            _transformController = transformController;
            _visibilityController = visibilityController;
            _characterController = characterController;
        }

        public GameObject ColliderObject => _characterController.gameObject;

        public bool IsVisible => _visibilityController.IsVisible;

        public Vector3 Position => _transformController.transform.position;
    }
}

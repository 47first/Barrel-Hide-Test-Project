using BarrelHide.Game.Characters.Components;
using UnityEngine;

namespace BarrelHide.Game.Characters.Facade.Impl
{
    public class PlayerFacade : IPlayerFacade
    {
        private readonly CharacterTransformController _transformController;
        private readonly CharacterController _characterController;

        public PlayerFacade(CharacterTransformController transformController)
        {
            _transformController = transformController;
        }

        public GameObject ColliderObject => _characterController.gameObject;

        public bool IsVisible { get; }

        public Vector3 Position => _transformController.transform.position;
    }
}

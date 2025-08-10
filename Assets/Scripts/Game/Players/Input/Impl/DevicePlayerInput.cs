using BarrelHide.Generated.InputActions;
using UnityEngine;

namespace BarrelHide.Game.Players.Input.Impl
{
    public class DevicePlayerInput : IPlayerInput
    {
        private readonly GameInputActions _gameInputActions;

        public DevicePlayerInput(GameInputActions gameInputActions)
        {
            _gameInputActions = gameInputActions;
        }

        public Vector2 MoveDirection => _gameInputActions.Player.Movement.ReadValue<Vector2>();
    }
}

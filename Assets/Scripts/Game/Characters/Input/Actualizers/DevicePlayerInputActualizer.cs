using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Generated.InputActions;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Input.Actualizers
{
    public class DevicePlayerInputActualizer : IFixedTickable
    {
        private readonly GameInputActions _gameInputActions;
        private readonly PlayerInput _input;

        public DevicePlayerInputActualizer(
            GameInputActions gameInputActions,
            PlayerInput input)
        {
            _gameInputActions = gameInputActions;
            _input = input;
        }

        public void FixedTick()
        {
            _input.MoveDirection = _gameInputActions.Player.Movement.ReadValue<Vector2>();
        }
    }
}

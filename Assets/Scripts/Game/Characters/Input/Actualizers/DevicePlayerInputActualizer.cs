using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Generated.InputActions;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Input.Actualizers
{
    public class DevicePlayerInputActualizer : IFixedTickable
    {
        private readonly IGameFlowController _gameFlowController;
        private readonly GameInputActions _gameInputActions;
        private readonly PlayerInput _input;

        public DevicePlayerInputActualizer(
            IGameFlowController gameFlowController,
            GameInputActions gameInputActions,
            PlayerInput input)
        {
            _gameFlowController = gameFlowController;
            _gameInputActions = gameInputActions;
            _input = input;
        }

        public void FixedTick()
        {
            if (_gameFlowController.Flow.CurrentValue is not GameFlow.Playing)
            {
                _input.MoveDirection = Vector2.zero;
                return;
            }

            _input.MoveDirection = _gameInputActions.Player.Movement.ReadValue<Vector2>();
        }
    }
}

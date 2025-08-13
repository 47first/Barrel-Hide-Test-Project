using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Generated.InputActions;
using UnityEngine.InputSystem;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class StartGameOnInputTrigger : IInitializable, IDisposable
    {
        private readonly GameInputActions _inputActions;
        private readonly IGameFlowController _gameFlowController;

        public StartGameOnInputTrigger(
            GameInputActions inputActions,
            IGameFlowController gameFlowController)
        {
            _inputActions = inputActions;
            _gameFlowController = gameFlowController;
        }

        public void Initialize()
        {
            _inputActions.Player.Movement.started += GameInputActions_PlayerMovementStarted;
        }

        public void Dispose()
        {
            _inputActions.Player.Movement.started -= GameInputActions_PlayerMovementStarted;
        }

        private void GameInputActions_PlayerMovementStarted(InputAction.CallbackContext callbackContext)
        {
            if (_gameFlowController.Flow.CurrentValue is not GameFlow.Pending)
            {
                return;
            }

            _gameFlowController.SetFlow(GameFlow.Playing);
        }
    }
}

using System;
using BarrelHide.Generated.InputActions;
using Zenject;

namespace BarrelHide.Game.Input
{
    public class GameInputActionsHandle : IInitializable, IDisposable
    {
        private GameInputActions _gameInputActions;

        public GameInputActionsHandle(GameInputActions gameInputActions)
        {
            _gameInputActions = gameInputActions;
        }

        public void Initialize()
        {
            _gameInputActions.Enable();
        }

        public void Dispose()
        {
            _gameInputActions.Dispose();
        }
    }
}

using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Flow.Options;
using R3;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class LoseOnTimeUpTrigger : IInitializable, IDisposable
    {
        private readonly IGameFlowController _gameFlowController;
        private readonly GameFlowOptions _options;

        private IDisposable _gameFlowControllerObserver;
        private IDisposable _timerObserver;

        public LoseOnTimeUpTrigger(
            IGameFlowController gameFlowController,
            GameFlowOptions options)
        {
            _gameFlowController = gameFlowController;
            _options = options;
        }

        public void Initialize()
        {
            _gameFlowControllerObserver = _gameFlowController.Flow
                .Subscribe(GameFlowController_FlowChanged);
        }

        private void GameFlowController_FlowChanged(GameFlow gameFlow)
        {
            if (gameFlow is GameFlow.Playing && _timerObserver is null)
            {
                _timerObserver = Observable
                    .Timer(TimeSpan.FromSeconds(_options.TimeToLose))
                    .Subscribe(LoseTimer_Triggered);

                return;
            }

            if (gameFlow is GameFlow.Lose or GameFlow.Won)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _gameFlowControllerObserver?.Dispose();
            _timerObserver?.Dispose();
        }

        private void LoseTimer_Triggered(Unit plug)
        {
            _gameFlowController.SetFlow(GameFlow.Lose);
        }
    }
}

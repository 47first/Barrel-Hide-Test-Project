using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class LoseOnTimeUpTrigger : IInitializable, IDisposable
    {
        private readonly IGameFlowController _gameFlowController;

        private IDisposable _gameFlowControllerObserver;
        private IDisposable _timerObserver;

        public LoseOnTimeUpTrigger(IGameFlowController gameFlowController)
        {
            _gameFlowController = gameFlowController;
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
                if (_gameFlowController.EndTime.HasValue == false)
                {
                    throw new InvalidOperationException($"End time must be set on '{GameFlow.Playing}' flow");
                }

                _timerObserver = Observable
                    .Timer(TimeSpan.FromSeconds(_gameFlowController.EndTime.Value - Time.time))
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

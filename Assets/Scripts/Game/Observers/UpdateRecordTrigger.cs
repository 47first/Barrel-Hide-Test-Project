using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Record;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class UpdateRecordTrigger : IInitializable, IDisposable
    {
        private readonly IGameFlowController _gameFlowController;
        private readonly IRecordController _recordController;

        private IDisposable _gameFlowControllerObserver;

        public UpdateRecordTrigger(
            IGameFlowController gameFlowController,
            IRecordController recordController)
        {
            _gameFlowController = gameFlowController;
            _recordController = recordController;
        }

        public void Initialize()
        {
            _gameFlowControllerObserver = _gameFlowController.Flow
                .Subscribe(GameFlowController_FlowChanged);
        }

        public void Dispose()
        {
            _gameFlowControllerObserver?.Dispose();
        }

        private void GameFlowController_FlowChanged(GameFlow gameFlow)
        {
            if (gameFlow is not GameFlow.Won ||
                _gameFlowController.PlayingTime.HasValue == false)
            {
                return;
            }

            _recordController.TrySetBestTimeSeconds(_gameFlowController.PlayingTime.Value);
        }
    }
}

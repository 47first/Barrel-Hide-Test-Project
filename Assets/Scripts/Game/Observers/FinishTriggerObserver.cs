using System;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Components;
using BarrelHide.Game.Flow.Enums;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class FinishTriggerObserver : IInitializable, IDisposable
    {
        private readonly FinishTrigger _finishTrigger;
        private readonly IPlayerFacade _player;
        private readonly IGameFlowController _gameFlowController;

        private IDisposable _observer;

        public FinishTriggerObserver(
            FinishTrigger finishTrigger,
            IPlayerFacade player,
            IGameFlowController gameFlowController)
        {
            _finishTrigger = finishTrigger;
            _player = player;
            _gameFlowController = gameFlowController;
        }

        public void Initialize()
        {
            _observer = _finishTrigger.TriggerEntered
                .Where(_player, (collider, player) =>
                    collider.gameObject == player.ColliderObject)
                .Where(_gameFlowController, (_, gameFlowController) =>
                    gameFlowController.Flow.CurrentValue is GameFlow.Pending)
                .Subscribe(FinishTrigger_PlayerEntered);
        }

        public void Dispose()
        {
            _observer?.Dispose();
        }

        private void FinishTrigger_PlayerEntered(Collider collider)
        {
            _gameFlowController.SetFlow(GameFlow.Won);
        }
    }
}

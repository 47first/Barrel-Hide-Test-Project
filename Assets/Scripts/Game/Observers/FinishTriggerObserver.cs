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
                .Where(_player, ColliderIsPlayer)
                .Where(_gameFlowController, GameFlowIsPlaying)
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

        private static bool ColliderIsPlayer(Collider collider, IPlayerFacade player)
        {
            return collider.gameObject == player.ColliderObject;
        }

        private static bool GameFlowIsPlaying(Collider collider, IGameFlowController gameFlowController)
        {
            return gameFlowController.Flow.CurrentValue is GameFlow.Playing;
        }
    }
}

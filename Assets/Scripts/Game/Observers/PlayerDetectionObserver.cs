using System;
using System.Collections.Generic;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Observers
{
    public class PlayerDetectionObserver : IInitializable, IDisposable
    {
        private readonly IGameFlowController _gameFlowController;
        private readonly List<IEnemyFacade> _enemies;

        private IDisposable _observers;

        public PlayerDetectionObserver(
            IGameFlowController gameFlowController,
            List<IEnemyFacade> enemies)
        {
            _gameFlowController = gameFlowController;
            _enemies = enemies;
        }

        public void Initialize()
        {
            var disposables = Disposable.CreateBuilder();

            Debug.Log("Initialize");

            foreach (var enemy in _enemies)
            {
                enemy.PlayerSpotted
                    .Where(_gameFlowController, GameFlowInPlaying)
                    .Subscribe(Enemy_PlayerSpotted)
                    .AddTo(ref disposables);

                Debug.Log("Enemy");
            }

            _observers = disposables.Build();
        }

        public void Dispose()
        {
            _observers?.Dispose();
        }

        private void Enemy_PlayerSpotted(IPlayerFacade playerFacade)
        {
            _gameFlowController.SetFlow(GameFlow.Lose);
        }

        private static bool GameFlowInPlaying(IPlayerFacade player, IGameFlowController gameFlowController)
        {
            return gameFlowController.Flow.CurrentValue is GameFlow.Playing;
        }
    }
}

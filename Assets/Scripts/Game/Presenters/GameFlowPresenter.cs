using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Record;
using BarrelHide.Game.Views;
using BarrelHide.Game.Views.Enums;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BarrelHide.Game.Presenters
{
    public class GameFlowPresenter : IInitializable, IDisposable, IFixedTickable
    {
        private readonly GameFlowView _gameFlowView;
        private readonly IRecordController _recordController;
        private readonly IGameFlowController _gameFlowController;

        private IDisposable _gameFlowControllerObserver;

        public GameFlowPresenter(
            GameFlowView gameFlowView,
            IRecordController recordController,
            IGameFlowController gameFlowController)
        {
            _gameFlowView = gameFlowView;
            _recordController = recordController;
            _gameFlowController = gameFlowController;
        }

        public void Initialize()
        {
            var bestTimeSeconds = _recordController.GetBestTimeSeconds();

            var topBarText = bestTimeSeconds.HasValue
                ? $"{bestTimeSeconds:0.0}s."
                : $"Barrel{Environment.NewLine}Hide";

            _gameFlowView.SetTopBarText(topBarText);

            _gameFlowView.AddResetButtonClickCallback(ResetButton_Clicked);

            _gameFlowControllerObserver = _gameFlowController.Flow
                .Subscribe(GameFlowController_FlowChanged);
        }

        public void Dispose()
        {
            _gameFlowControllerObserver?.Dispose();

            _gameFlowView.RemoveButtonClickCallback(ResetButton_Clicked);
        }

        public void FixedTick()
        {
            if (_gameFlowController.EndTime.HasValue == false ||
                _gameFlowController.TimeToLose.HasValue == false)
            {
                return;
            }

            var timeLeftPercentage = (_gameFlowController.EndTime.Value - Time.time) / _gameFlowController.TimeToLose.Value;
            _gameFlowView.SetTimeSliderValue(timeLeftPercentage);
        }

        private void GameFlowController_FlowChanged(GameFlow gameFlow)
        {
            var viewState = gameFlow switch
            {
                GameFlow.Pending => GameFlowViewState.Pending,
                GameFlow.Playing => GameFlowViewState.Playing,
                GameFlow.Lose => GameFlowViewState.Lose,
                GameFlow.Won => GameFlowViewState.Won,
                _ => throw new ArgumentOutOfRangeException()
            };

            switch (viewState)
            {
                case GameFlowViewState.Won:
                    _gameFlowView.SetTopBarText("Won");
                    break;

                case GameFlowViewState.Lose:
                    _gameFlowView.SetTopBarText("Lose");
                    break;
            }

            _gameFlowView.SetState(viewState);
        }

        private void ResetButton_Clicked()
        {
            var activeScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(activeScene.name);
        }
    }
}

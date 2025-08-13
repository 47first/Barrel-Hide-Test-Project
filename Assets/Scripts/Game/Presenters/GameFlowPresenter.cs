using System;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Views;
using R3;
using Zenject;

namespace BarrelHide.Game.Presenters
{
    public class GameFlowPresenter : IInitializable, IDisposable
    {
        private readonly GameFlowView _gameFlowView;
        private readonly IGameFlowController _gameFlowController;

        public GameFlowPresenter(
            GameFlowView gameFlowView,
            IGameFlowController gameFlowController)
        {
            _gameFlowView = gameFlowView;
            _gameFlowController = gameFlowController;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}

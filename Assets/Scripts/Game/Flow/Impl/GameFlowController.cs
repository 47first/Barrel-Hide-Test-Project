using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Flow.Exceptions;
using R3;
using UnityEngine;

namespace BarrelHide.Game.Flow.Impl
{
    public class GameFlowController : IGameFlowController
    {
        private readonly ReactiveProperty<GameFlow> _flow = new(GameFlow.Playing);

        public ReadOnlyReactiveProperty<GameFlow> Flow => _flow;

        public void SetFlow(GameFlow value)
        {
            if (value is GameFlow.Pending ||
                value is GameFlow.Playing && _flow.Value is not GameFlow.Pending ||
                value is GameFlow.Lose or GameFlow.Won && _flow.Value is not GameFlow.Playing)
            {
                throw new InvalidFlowTransitionException(_flow.Value, value);
            }

            _flow.Value = value;
            Debug.Log($"Flow changed to {_flow.Value}");
        }
    }
}

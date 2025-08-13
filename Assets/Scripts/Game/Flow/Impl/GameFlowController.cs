using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Flow.Exceptions;
using BarrelHide.Game.Flow.Options;
using R3;
using UnityEngine;

namespace BarrelHide.Game.Flow.Impl
{
    public class GameFlowController : IGameFlowController
    {
        private readonly GameFlowOptions _options;

        private readonly ReactiveProperty<GameFlow> _flow = new(GameFlow.Pending);
        private float? _endTime;

        public GameFlowController(GameFlowOptions options)
        {
            _options = options;
        }

        public ReadOnlyReactiveProperty<GameFlow> Flow => _flow;

        public float? EndTime => _endTime;

        public void SetFlow(GameFlow value)
        {
            if (value is GameFlow.Pending ||
                value is GameFlow.Playing && _flow.Value is not GameFlow.Pending ||
                value is GameFlow.Lose or GameFlow.Won && _flow.Value is not GameFlow.Playing)
            {
                throw new InvalidFlowTransitionException(_flow.Value, value);
            }

            if (value is GameFlow.Playing)
            {
                _endTime = Time.time + _options.TimeToLose;
            }
            else
            {
                _endTime = null;
            }

            _flow.Value = value;
        }
    }
}

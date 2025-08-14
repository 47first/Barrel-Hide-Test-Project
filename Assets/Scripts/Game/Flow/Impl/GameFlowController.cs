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
        private float? _timeToLose;
        private float? _endTime;
        private float? _playingTime;

        public GameFlowController(GameFlowOptions options)
        {
            _options = options;
        }

        public ReadOnlyReactiveProperty<GameFlow> Flow => _flow;

        public float? TimeToLose => _timeToLose;

        public float? EndTime => _endTime;

        public float? PlayingTime => _playingTime;

        public void SetFlow(GameFlow value)
        {
            if (value is GameFlow.Pending ||
                value is GameFlow.Playing && _flow.Value is not GameFlow.Pending ||
                value is GameFlow.Lose or GameFlow.Won && _flow.Value is not GameFlow.Playing)
            {
                throw new InvalidFlowTransitionException(_flow.Value, value);
            }

            _playingTime = value is GameFlow.Won or GameFlow.Lose && _endTime.HasValue
                ? Mathf.Max(_endTime.Value - Time.time, 0)
                : null;

            if (value is GameFlow.Playing)
            {
                _timeToLose = _options.TimeToLose;
                _endTime = Time.time + _timeToLose;
            }
            else
            {
                _timeToLose = null;
                _endTime = null;
            }

            _flow.Value = value;
        }
    }
}

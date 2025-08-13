using BarrelHide.Game.Flow.Enums;
using R3;

namespace BarrelHide.Game.Flow
{
    public interface IGameFlowController
    {
        public ReadOnlyReactiveProperty<GameFlow> Flow { get; }

        public float? EndTime { get; }

        public void SetFlow(GameFlow value);
    }
}

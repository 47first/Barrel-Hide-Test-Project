using System;
using BarrelHide.Game.Flow.Enums;

namespace BarrelHide.Game.Flow.Exceptions
{
    public class InvalidFlowTransitionException : Exception
    {
        public InvalidFlowTransitionException(GameFlow current, GameFlow target)
            : base($"Can not change flow from {current} to {target}")
        {
        }
    }
}

using BarrelHide.Game.Focus.Enums;
using R3;

namespace BarrelHide.Game.Focus
{
    public interface IInputFocusController
    {
        public ReadOnlyReactiveProperty<InputFocusState> State { get; }
    }
}

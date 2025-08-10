using BarrelHide.Game.Consts;
using BarrelHide.Game.Players.Configuration.Options;
using BarrelHide.Generated.InputActions;
using UnityEngine;

namespace BarrelHide.Game.Configuration.Options
{
    [CreateAssetMenu(
        fileName = nameof(GameOptions),
        menuName = MenuNameConst.GameOptions)]
    public class GameOptions : ScriptableObject
    {
        [field: SerializeField] public PlayerOptions PlayerOptions { get; private set; }

        [field: SerializeField] public GameInputActions InputActions { get; private set; }
    }
}

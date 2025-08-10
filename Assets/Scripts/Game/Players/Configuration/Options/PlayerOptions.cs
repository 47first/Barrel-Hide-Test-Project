using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Players.Configuration.Options
{
    [CreateAssetMenu(
        fileName = nameof(PlayerOptions),
        menuName = MenuNameConst.PlayerOptions)]
    public class PlayerOptions : ScriptableObject
    {
        [field: Header(HeaderConst.Movement)]
        [field: SerializeField] public float MoveSpeed { get; private set; }

        [field: SerializeField] public float MovementMagnitudeError { get; private set; }

        [field: Header(HeaderConst.View)]
        [field: SerializeField] public float RotationLerpSpeed { get; private set; }

        [field: SerializeField] public float RotationDeltaPositionMagnitudeError { get; private set; }
    }
}

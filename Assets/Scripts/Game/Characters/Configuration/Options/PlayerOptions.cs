using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Characters.Configuration.Options
{
    [CreateAssetMenu(
        fileName = nameof(PlayerOptions),
        menuName = MenuNameConst.PlayerOptions)]
    public class PlayerOptions : ScriptableObject, ICharacterOptions
    {
        [field: Header(HeaderConst.Movement)]
        [field: SerializeField] public float MoveSpeed { get; private set; }

        [field: Header(HeaderConst.View)]
        [field: SerializeField] public float RotationLerpSpeed { get; private set; }
    }
}

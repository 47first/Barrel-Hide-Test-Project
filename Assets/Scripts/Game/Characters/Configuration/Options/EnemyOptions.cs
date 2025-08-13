using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Characters.Configuration.Options
{
    [CreateAssetMenu(
        fileName = nameof(EnemyOptions),
        menuName = MenuNameConst.EnemyOptions)]
    public class EnemyOptions : ScriptableObject, ICharacterOptions
    {
        [field: Header(HeaderConst.Options)]
        [field: SerializeField] public float DetectionRadius { get; private set; }

        [field: SerializeField] public float ChangeWayPointRange { get; private set; }

        [field: Header(HeaderConst.Movement)]
        [field: SerializeField] public float MoveSpeed { get; private set; }

        [field: Header(HeaderConst.View)]
        [field: SerializeField] public float RotationLerpSpeed { get; private set; }

        [field: SerializeField] public float RotationDeltaPositionMagnitudeError { get; private set; }
    }
}

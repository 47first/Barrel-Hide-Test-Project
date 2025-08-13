using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Flow.Options
{
    [CreateAssetMenu(
        fileName = nameof(GameFlowOptions),
        menuName = MenuNameConst.GameFlowOptions)]
    public class GameFlowOptions : ScriptableObject
    {
        [field: Header(HeaderConst.Options)]
        [field: SerializeField] public float TimeToLose { get; private set; }
    }
}

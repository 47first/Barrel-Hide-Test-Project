using BarrelHide.Game.Camera.Options;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Flow.Options;
using UnityEngine;

namespace BarrelHide.Game.Configuration.Options
{
    [CreateAssetMenu(
        fileName = nameof(GameOptions),
        menuName = MenuNameConst.GameOptions)]
    public class GameOptions : ScriptableObject
    {
        [field: Header(HeaderConst.References)]
        [field: SerializeField] public CameraOptions CameraOptions { get; private set; }

        [field: SerializeField] public GameFlowOptions GameFlowOptions { get; private set; }
    }
}

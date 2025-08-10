using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Camera.Options
{
    [CreateAssetMenu(
        fileName = nameof(CameraOptions),
        menuName = MenuNameConst.CameraOptions)]
    public class CameraOptions : ScriptableObject
    {
        [Header(HeaderConst.Options)]
        [field: SerializeField] public Vector3 PositionOffset { get; private set; }
    }
}

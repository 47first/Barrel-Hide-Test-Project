using BarrelHide.Game.Camera.Options;
using BarrelHide.Game.Consts;
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
    }
}

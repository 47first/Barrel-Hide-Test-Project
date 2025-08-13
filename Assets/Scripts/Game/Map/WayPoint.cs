using BarrelHide.Game.Consts;
using UnityEngine;

namespace BarrelHide.Game.Map
{
    public class WayPoint : MonoBehaviour
    {
        [field: Header(HeaderConst.References)]
        [field: SerializeField] public WayPoint[] Links { get; private set; }

        public Vector3 Position => transform.position;
    }
}

using UnityEngine;

namespace BarrelHide.Game.Map
{
    public class WayPoint : MonoBehaviour
    {
        [field: SerializeField] public WayPoint[] Links { get; private set; }

        public Vector3 Position => transform.position;
    }
}

using UnityEngine;

namespace BarrelHide.Game.Map
{
    public class EnemyWayPoint : MonoBehaviour
    {
        [field: SerializeField] public Transform[] ConnectedWayPoints { get; private set; }

        public Vector3 Position => transform.position;
    }
}

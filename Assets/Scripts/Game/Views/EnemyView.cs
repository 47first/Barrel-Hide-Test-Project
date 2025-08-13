using BarrelHide.Game.Consts;
using BarrelHide.Game.Views.Enums;
using UnityEngine;

namespace BarrelHide.Game.Views
{
    public class EnemyView : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private Transform _detectionCircleTransform;
        [SerializeField] private Animator _animator;

        public void SetPosition(Vector3 position)
        {
            _rootTransform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            _rootTransform.rotation = rotation;
        }

        public void SetDetectionCircleRadius(float radius)
        {
            _detectionCircleTransform.transform.localScale = new Vector3(radius, radius, radius);
        }

        public void SetState(EnemyViewState state)
        {
            _animator.SetInteger(AnimatorHashConst.State, (int)state);
        }
    }
}

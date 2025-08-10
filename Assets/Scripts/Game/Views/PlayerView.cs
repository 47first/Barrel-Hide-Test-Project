using BarrelHide.Game.Consts;
using BarrelHide.Game.Views.Enums;
using UnityEngine;

namespace BarrelHide.Game.Views
{
    public class PlayerView : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private Animator _animator;

        public void SetPosition(Vector3 position)
        {
            _rootTransform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            _rootTransform.rotation = rotation;
        }

        public void SetState(PlayerViewState state)
        {
            _animator.SetInteger(AnimatorHashConst.State, (int)state);
        }
    }
}

using BarrelHide.Game.Consts;
using BarrelHide.Game.Views.Enums;
using UnityEngine;

namespace BarrelHide.Game.Views
{
    public class PlayerView : MonoBehaviour
    {

        [Header(HeaderConst.References)]
        [SerializeField] private Transform _rootTransform;
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Animator _barrelAnimator;

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
            _playerAnimator.SetInteger(AnimatorHashConst.State, (int)state);

            if (state is PlayerViewState.Won or PlayerViewState.Lose)
            {
                _barrelAnimator.SetBool(AnimatorHashConst.Destroyed, true);
            }
        }
    }
}

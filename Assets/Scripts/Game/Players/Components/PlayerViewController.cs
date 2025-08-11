using BarrelHide.Game.Players.Configuration.Options;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Components
{
    public class PlayerViewController : MonoBehaviour
    {
        [Inject] private PlayerView _view;
        [Inject] private PlayerOptions _options;
        [Inject] private PlayerTransformController _transformController;

        private Quaternion _targetRotation;

        private void FixedUpdate()
        {
            if (_transformController.FixedDeltaPosition != Vector3.zero)
            {
                _targetRotation = Quaternion.LookRotation(_transformController.FixedDeltaPosition);
            }

            var currentRotation = Quaternion.Lerp(
                transform.rotation,
                _targetRotation,
                _options.RotationLerpSpeed);

            _view.SetRotation(currentRotation);
        }
    }
}

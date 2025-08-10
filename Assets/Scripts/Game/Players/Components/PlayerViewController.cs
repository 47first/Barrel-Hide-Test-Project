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

        private Vector3 _previousFixedPosition;
        private Quaternion _targetRotation;

        private void FixedUpdate()
        {
            var fixedDeltaPosition = transform.position - _previousFixedPosition;

            _previousFixedPosition = transform.position;

            if (fixedDeltaPosition != Vector3.zero)
            {
                _targetRotation = Quaternion.LookRotation(fixedDeltaPosition);
            }

            var currentRotation = Quaternion.Lerp(
                transform.rotation,
                _targetRotation,
                _options.RotationLerpSpeed);

            _view.SetRotation(currentRotation);
        }
    }
}

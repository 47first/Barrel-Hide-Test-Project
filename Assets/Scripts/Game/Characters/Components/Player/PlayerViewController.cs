using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Views;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Player
{
    public class PlayerViewController : MonoBehaviour
    {
        [Inject] private PlayerView _view;
        [Inject] private PlayerOptions _options;
        [Inject] private CharacterTransformController _transformController;

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

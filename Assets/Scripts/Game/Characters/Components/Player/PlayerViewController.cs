using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using BarrelHide.Game.Views;
using BarrelHide.Game.Views.Enums;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Player
{
    public class PlayerViewController : MonoBehaviour
    {
        [Inject] private PlayerView _view;
        [Inject] private PlayerOptions _options;
        [Inject] private CharacterTransformController _transformController;
        [Inject] private IGameFlowController _gameFlowController;

        private Quaternion _currentRotation = Quaternion.identity;
        private Quaternion _targetRotation = Quaternion.identity;
        private PlayerViewState _state;

        private void FixedUpdate()
        {
            if (_transformController.FixedDeltaPosition != Vector3.zero)
            {
                _targetRotation = Quaternion.LookRotation(_transformController.FixedDeltaPosition);
            }

            _currentRotation = Quaternion.Lerp(
                _currentRotation,
                _targetRotation,
                _options.RotationLerpSpeed);

            _view.SetRotation(_currentRotation);
            _view.SetPosition(_transformController.Position);

            if (TrySetNewViewState())
            {
                _view.SetState(_state);
            }
        }

        private bool TrySetNewViewState()
        {
            var newState = _gameFlowController.Flow.CurrentValue switch
            {
                GameFlow.Lose => PlayerViewState.Lose,
                GameFlow.Won => PlayerViewState.Won,
                GameFlow.Playing when _transformController.FixedDeltaPosition.magnitude > 0 => PlayerViewState.Moving,
                _ => PlayerViewState.Idle
            };

            var hasChanges = newState != _state;
            _state = newState;

            return hasChanges;
        }
    }
}

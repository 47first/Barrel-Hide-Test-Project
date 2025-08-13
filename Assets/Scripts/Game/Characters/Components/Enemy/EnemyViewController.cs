using System;
using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Views;
using BarrelHide.Game.Views.Enums;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Enemy
{
    public class EnemyViewController : MonoBehaviour
    {
        [Inject] private EnemyView _view;
        [Inject] private EnemyOptions _options;
        [Inject] private EnemyAIController _aiController;
        [Inject] private CharacterTransformController _transformController;

        private IDisposable _observer;
        private Quaternion _currentRotation = Quaternion.identity;
        private Quaternion _targetRotation = Quaternion.identity;
        private EnemyViewState _state;

        private void Start()
        {
            _view.SetDetectionCircleRadius(_options.DetectionRadius);

            _observer = _aiController.PlayerSpottedEvent
                .Subscribe(AIController_PlayerSpotted);
        }

        private void OnDestroy()
        {
            _observer?.Dispose();
        }

        private void FixedUpdate()
        {
            if (_transformController.FixedDeltaPosition != Vector3.zero &&
                _state is not EnemyViewState.Shooting)
            {
                _targetRotation = Quaternion.LookRotation(_transformController.FixedDeltaPosition);
            }

            _currentRotation = Quaternion.Lerp(
                _currentRotation,
                _targetRotation,
                _options.RotationLerpSpeed);

            _view.SetRotation(_currentRotation);
            _view.SetPosition(_transformController.Position);
            ActualizeViewState();
        }

        private void ActualizeViewState()
        {
            if (_state is EnemyViewState.Shooting)
            {
                return;
            }

            var newState = _transformController.FixedDeltaPosition switch
            {
                { magnitude: > 0 } => EnemyViewState.Move,
                _ => EnemyViewState.Idle
            };

            if (newState != _state)
            {
                SetState(newState);
            }
        }

        private void SetState(EnemyViewState state)
        {
            _state = state;

            _view.SetState(_state);
        }

        private void AIController_PlayerSpotted(IPlayerFacade playerFacade)
        {
            _targetRotation = Quaternion.LookRotation(playerFacade.Position - _transformController.Position);

            SetState(EnemyViewState.Shooting);
        }
    }
}

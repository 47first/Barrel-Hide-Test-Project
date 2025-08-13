using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Map;
using R3;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [field: SerializeField] public WayPoint TargetWayPoint { get; set; }

        [Inject] private IPlayerFacade _player;
        [Inject] private EnemyOptions _options;
        [Inject] private CharacterTransformController _transformController;

        private readonly Subject<IPlayerFacade> _playerSpottedSubject = new();

        public Observable<IPlayerFacade> PlayerSpottedEvent => _playerSpottedSubject;

        private void FixedUpdate()
        {
            DefineTargetWayPoint();

            CheckCanSeePlayer();
        }

        private void DefineTargetWayPoint()
        {
            var relativePositionToWayPoint = _transformController.Position - TargetWayPoint.Position;

            if (relativePositionToWayPoint.magnitude < _options.ChangeWayPointRange)
            {
                var linkIndex = Random.Range(0, TargetWayPoint.Links.Length);

                TargetWayPoint = TargetWayPoint.Links[linkIndex];
            }
        }

        private void CheckCanSeePlayer()
        {
            var relativePosition = _player.Position - _transformController.Position;

            if (_player.IsVisible &&
                relativePosition.magnitude < _options.DetectionRadius &&
                Physics.Raycast(
                    origin: _transformController.Position + Vector3.up,
                    direction: relativePosition,
                    hitInfo: out var result,
                    maxDistance: _options.DetectionRadius) &&
                result.collider.gameObject == _player.ColliderObject)
            {
                _playerSpottedSubject.OnNext(_player);
            }
        }
    }
}

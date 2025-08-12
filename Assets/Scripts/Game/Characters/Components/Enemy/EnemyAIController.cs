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
        private readonly Subject<IPlayerFacade> _playerSpottedSubject = new();

        [Inject] private IPlayerFacade _player;
        [Inject] private EnemyOptions _options;
        [Inject] private CharacterTransformController _transformController;

        [Header(HeaderConst.References)]
        [field: SerializeField] public WayPoint TargetWayPoint { get; set; }

        public Observable<IPlayerFacade> PlayerSpotted => _playerSpottedSubject;

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
                relativePosition.magnitude < _options.DetectionRange &&
                Physics.Raycast(_transformController.Position + Vector3.up, relativePosition, out var result, _options.DetectionRange) &&
                result.collider.gameObject == _player.ColliderObject)
            {
                Debug.Log($"Detected {result.collider.gameObject.name}");
                _playerSpottedSubject.OnNext(_player);
            }
        }
    }
}

using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Enums;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Consts;
using BarrelHide.Game.Map;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [Inject] private IPlayerFacade _player;
        [Inject] private EnemyOptions _options;
        [Inject] private CharacterTransformController _transformController;

        [Header(HeaderConst.References)]
        [field: SerializeField] public WayPoint WayPoint { get; set; }

        public EnemyAIState State { get; set; }

        private void FixedUpdate()
        {
            var relativePosition = _player.Position - _transformController.Position;

            if (_player.IsVisible &&
                relativePosition.magnitude > _options.DetectionRange &&
                Physics.Raycast(_transformController.Position, relativePosition, out var result, _options.DetectionRange) &&
                result.collider == _transformController.GetComponent<Collider>())
            {
                Debug.Log("Detected");
            }
        }
    }
}

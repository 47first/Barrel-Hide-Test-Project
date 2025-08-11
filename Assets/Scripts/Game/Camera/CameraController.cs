using BarrelHide.Game.Camera.Options;
using BarrelHide.Game.Characters.Facade;
using BarrelHide.Game.Consts;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [SerializeField] private UnityEngine.Camera _camera;

        [Inject] private IPlayerFacade _player;
        [Inject] private CameraOptions _options;

        private void FixedUpdate()
        {
            var targetPosition = _player.Position + _options.PositionOffset;

            _camera.transform.position = targetPosition;
        }
    }
}

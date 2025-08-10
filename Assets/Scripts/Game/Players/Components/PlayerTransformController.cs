using BarrelHide.Game.Players.Configuration.Options;
using BarrelHide.Game.Players.Input;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Components
{
    public class PlayerTransformController : MonoBehaviour
    {
        [Inject] private CharacterController _characterController;
        [Inject] private PlayerOptions _options;
        [Inject] private IPlayerInput _input;

        private void FixedUpdate()
        {
            if (_input.MoveDirection.magnitude < _options.MovementMagnitudeError)
            {
                return;
            }

            var moveDirection = new Vector3(_input.MoveDirection.x, 0, _input.MoveDirection.y).normalized;
            _characterController.SimpleMove(moveDirection * _options.MoveSpeed);
        }
    }
}

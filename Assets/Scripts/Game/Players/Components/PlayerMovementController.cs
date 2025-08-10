using BarrelHide.Game.Players.Configuration.Options;
using BarrelHide.Game.Players.Input;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Components
{
    public class PlayerMovementController : MonoBehaviour
    {
        private CharacterController _characterController;
        private PlayerOptions _options;
        private IPlayerInput _input;

        [Inject]
        public void InjectBindings(
            CharacterController characterController,
            PlayerOptions options,
            IPlayerInput input)
        {
            _characterController = characterController;
            _options = options;
            _input = input;
        }

        private void FixedUpdate()
        {
            if (_input.MoveDirection.magnitude < _options.MovementMagnitudeError)
            {
                return;
            }

            var moveSpeed = new Vector3(_input.MoveDirection.x, 0, _input.MoveDirection.y);
            _characterController.SimpleMove(moveSpeed);
        }
    }
}

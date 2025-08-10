using BarrelHide.Game.Consts;
using BarrelHide.Game.Players.Configuration.Options;
using BarrelHide.Game.Players.Input;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Players.Components
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [SerializeField] private CharacterController _characterController;

        private PlayerOptions _options;
        private IPlayerInput _input;

        [Inject]
        public void InjectBindings(
            PlayerOptions options,
            IPlayerInput input)
        {
            _options = options;
            _input = input;
        }

        private void FixedUpdate()
        {
            if (_input.MoveDirection.magnitude < _options.MovementMagnitudeError)
            {
                return;
            }

            _characterController.SimpleMove(_input.MoveDirection);
        }
    }
}

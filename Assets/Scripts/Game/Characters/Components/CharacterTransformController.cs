using BarrelHide.Game.Characters.Configuration.Options;
using BarrelHide.Game.Characters.Input;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components
{
    public class CharacterTransformController : MonoBehaviour
    {
        [Inject] private CharacterController _characterController;
        [Inject] private ICharacterOptions _options;
        [Inject] private ICharacterInput _input;

        private Vector3 _previousFixedPosition;

        public Vector3 Position => transform.position;

        public Vector3 FixedDeltaPosition { get; private set; }

        private void FixedUpdate()
        {
            FixedDeltaPosition = transform.position - _previousFixedPosition;
            _previousFixedPosition = transform.position;

            var moveDirection = new Vector3(_input.MoveDirection.x, 0, _input.MoveDirection.y).normalized;
            _characterController.SimpleMove(moveDirection * _options.MoveSpeed);
        }
    }
}

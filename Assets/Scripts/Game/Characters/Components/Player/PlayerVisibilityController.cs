using BarrelHide.Game.Characters.Configuration.Options;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Player
{
    public class PlayerVisibilityController : MonoBehaviour
    {
        [Inject] private CharacterTransformController _transformController;
        [Inject] private PlayerOptions _options;

        private float _previousVisibleTime;

        public bool IsVisible { get; private set; }

        private void FixedUpdate()
        {
            IsVisible = _transformController.FixedDeltaPosition != Vector3.zero;
        }
    }
}

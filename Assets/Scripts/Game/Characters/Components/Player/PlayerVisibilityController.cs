using BarrelHide.Game.Characters.Configuration.Options;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Components.Player
{
    public class PlayerVisibilityController : MonoBehaviour
    {
        [Inject] private CharacterTransformController _transformController;
        [Inject] private PlayerOptions _options;

        public bool IsVisible { get; private set; }

        private float _previousVisibleTime;

        private void FixedUpdate()
        {
            IsVisible = _transformController.FixedDeltaPosition != Vector3.zero;
        }
    }
}

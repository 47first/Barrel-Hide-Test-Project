using UnityEngine;

namespace BarrelHide.Game.Characters.Facade
{
    public interface IPlayerFacade
    {
        public GameObject ColliderObject { get; }

        public bool IsVisible { get; }

        public Vector3 Position { get; }
    }
}

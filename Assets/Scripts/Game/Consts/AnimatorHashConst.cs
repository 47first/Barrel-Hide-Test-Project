using UnityEngine;

namespace BarrelHide.Game.Consts
{
    public static class AnimatorHashConst
    {
        public static int State { get; } = Animator.StringToHash("State");

        public static int Destroyed { get; } = Animator.StringToHash("Destroyed");
    }
}

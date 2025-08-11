using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Enemy;
using BarrelHide.Game.Characters.Input.Models;
using Zenject;

namespace BarrelHide.Game.Characters.Input.Actualizers
{
    public class AIEnemyInputActualizer : IFixedTickable
    {
        private readonly CharacterTransformController _transformController;
        private readonly EnemyAIController _aiController;
        private readonly EnemyInput _input;

        public AIEnemyInputActualizer(
            CharacterTransformController transformController,
            EnemyAIController aiController,
            EnemyInput input)
        {
            _transformController = transformController;
            _aiController = aiController;
            _input = input;
        }

        public void FixedTick()
        {
            _input.MoveDirection = (_transformController.Position - _aiController.WayPoint.Position).normalized;
        }
    }
}

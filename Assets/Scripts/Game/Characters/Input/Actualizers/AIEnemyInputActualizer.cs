using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Enemy;
using BarrelHide.Game.Characters.Input.Models;
using UnityEngine;
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
            var convertedWayPointPosition = new Vector2(
                _aiController.TargetWayPoint.Position.x,
                _aiController.TargetWayPoint.Position.z);

            var convertedCharacterPosition = new Vector2(
                _transformController.Position.x,
                _transformController.Position.z);

            _input.MoveDirection = (convertedWayPointPosition - convertedCharacterPosition).normalized;
        }
    }
}

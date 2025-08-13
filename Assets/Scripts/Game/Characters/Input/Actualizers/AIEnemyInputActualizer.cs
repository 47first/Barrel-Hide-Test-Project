using BarrelHide.Game.Characters.Components;
using BarrelHide.Game.Characters.Components.Enemy;
using BarrelHide.Game.Characters.Input.Models;
using BarrelHide.Game.Flow;
using BarrelHide.Game.Flow.Enums;
using UnityEngine;
using Zenject;

namespace BarrelHide.Game.Characters.Input.Actualizers
{
    public class AIEnemyInputActualizer : IFixedTickable
    {
        private readonly CharacterTransformController _transformController;
        private readonly IGameFlowController _gameFlowController;
        private readonly EnemyAIController _aiController;
        private readonly EnemyInput _input;

        public AIEnemyInputActualizer(
            CharacterTransformController transformController,
            IGameFlowController gameFlowController,
            EnemyAIController aiController,
            EnemyInput input)
        {
            _transformController = transformController;
            _gameFlowController = gameFlowController;
            _aiController = aiController;
            _input = input;
        }

        public void FixedTick()
        {
            if (_gameFlowController.Flow.CurrentValue is not GameFlow.Playing)
            {
                _input.MoveDirection = Vector2.zero;
                return;
            }

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

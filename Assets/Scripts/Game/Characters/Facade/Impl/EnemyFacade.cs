using BarrelHide.Game.Characters.Components.Enemy;
using R3;

namespace BarrelHide.Game.Characters.Facade.Impl
{
    public class EnemyFacade : IEnemyFacade
    {
        private readonly EnemyAIController _aiController;

        public EnemyFacade(EnemyAIController aiController)
        {
            _aiController = aiController;
        }

        public Observable<IPlayerFacade> PlayerSpotted => _aiController.PlayerSpottedEvent;
    }
}

using R3;

namespace BarrelHide.Game.Characters.Facade
{
    public interface IEnemyFacade
    {
        public Observable<IPlayerFacade> PlayerSpotted { get; }
    }
}

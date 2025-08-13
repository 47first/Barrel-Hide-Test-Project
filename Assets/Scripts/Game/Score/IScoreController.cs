namespace BarrelHide.Game.Score
{
    public interface IScoreController
    {
        public float? GetBestTime();

        public void SetBestTime(float time);
    }
}

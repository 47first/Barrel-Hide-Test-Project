namespace BarrelHide.Game.Record
{
    public interface IRecordController
    {
        public float? GetBestTimeSeconds();

        public bool TrySetBestTimeSeconds(float time);
    }
}

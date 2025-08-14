using UnityEngine;

namespace BarrelHide.Game.Record.Impl
{
    public class RecordController : IRecordController
    {
        private const string BestTimeKey = "BestTime";

        public float? GetBestTimeSeconds()
        {
            if (PlayerPrefs.HasKey(BestTimeKey))
            {
                return PlayerPrefs.GetFloat(BestTimeKey);
            }

            return null;
        }

        public bool TrySetBestTimeSeconds(float time)
        {
            var bestTime = GetBestTimeSeconds();

            if (bestTime.HasValue && bestTime.Value < time)
            {
                return false;
            }

            PlayerPrefs.SetFloat(BestTimeKey, time);
            return true;
        }
    }
}

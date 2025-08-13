using UnityEngine;

namespace BarrelHide.Game.Score.Impl
{
    public class ScoreController : IScoreController
    {
        private const string BestTimeKey = "BestTime";

        public float? GetBestTime()
        {
            if (PlayerPrefs.HasKey(BestTimeKey))
            {
                return PlayerPrefs.GetFloat(BestTimeKey);
            }

            return null;
        }

        public void SetBestTime(float time)
        {
            PlayerPrefs.SetFloat(BestTimeKey, time);
        }
    }
}

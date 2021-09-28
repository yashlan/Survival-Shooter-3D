using UnityEngine.UI;
using Yashlan.util;

namespace Yashlan.manage
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public static int score;
        public Text textScore;
        public Text textKills;
        public Text textPowerUp;
        public int KillCount;

        void Start()
        {
            score = 0;
            KillCount = 0;
            textKills.text = $"Kills : {KillCount}";
            textPowerUp.text = "Power Up : 0";
        }

        void Update() => textScore.text = $"Score: {score}";

        public void IncerementKillCount() 
        {
            KillCount++;
            textKills.text = $"Kills : {KillCount}";
        } 

        public void SetTextPowerUp(float time) => textPowerUp.text = $"Power Up : {(int)time}";

    }
}
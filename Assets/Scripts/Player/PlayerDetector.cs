using UnityEngine;
using Yashlan.manage;

namespace Yashlan.player
{
    public class PlayerDetector : MonoBehaviour
    {
        public GameOverManager gameOverManager;

        float delay;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy" && !other.isTrigger && delay < Time.time)
            {
                //dapatkan jarak antara enemy dengan player
                float enemyDistance = Vector3.Distance(transform.position, other.transform.position);

                //akan muncul text tanda seru jika jarak sesuai dengan kondisi di ShowWaring()
                gameOverManager.ShowWarning(enemyDistance);

                //diberi delay 1 detik agar tidak mengecek terus menerus
                delay = Time.time + 1f;
            }
        }
    }
}
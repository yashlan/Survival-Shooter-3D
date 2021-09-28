using UnityEngine;
using Yashlan.manage;
using Yashlan.player;
using Yashlan.ui;

namespace Yashlan.item
{
    //fitur tamabahan
    public class ItemPowerUp : Item
    {
        [Header("Abillity")]
        public float powerUpTime;
        public int damage;
        public float playerSpeed;
        public float timeBetweenBullets;
        public float range;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //mendapatkan komponen dari collision
                var playerShoot = collision.gameObject.GetComponentInChildren<PlayerShooting>();

                //ubah artibut
                playerShoot.PowerUp(powerUpTime, playerSpeed, damage, timeBetweenBullets, range);

                //floating text power up info
                TextInfoUI.Instance.ShowTextInfo("Power Up!", Color.red);

                //putar audio sfx
                AudioManager.Instance.PlaySFX(collectSound);

                //kemudian destroy
                Destroy(gameObject);
            }
        }
    }
}
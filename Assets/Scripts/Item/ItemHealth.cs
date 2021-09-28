using UnityEngine;
using Yashlan.manage;
using Yashlan.player;
using Yashlan.ui;

namespace Yashlan.item
{
    //fitur tambahan
    public class ItemHealth : Item
    {
        //banyaknya jumlah darah yang akan ditambahkan
        [Header("Abillity")]
        public int healthAmount;

        void OnCollisionEnter(Collision collision)
        {
            //jika bercollision dengan player dan darah player > 0
            if (collision.gameObject.tag == "Player")
            {
                var player = collision.gameObject.GetComponent<PlayerHealth>();

                if(player.currentHealth > 0)
                {
                    //handle agar darah tidak melewati atau pffset dari darah awal player
                    if ((player.currentHealth + healthAmount) >= player.startingHealth)
                    {
                        player.currentHealth = player.startingHealth;
                        player.healthSlider.value = player.currentHealth;
                    }
                    //selain itu maka darah akan ditambahkan sesuai healthAmount
                    else
                    {
                        player.currentHealth += healthAmount;
                        player.healthSlider.value = player.currentHealth;
                    }
                }
                //floating text power up info
                TextInfoUI.Instance.ShowTextInfo($"Health +{healthAmount}", Color.green);

                //putar sfx
                AudioManager.Instance.PlaySFX(collectSound);

                Destroy(gameObject);
            }
        }
    }
}
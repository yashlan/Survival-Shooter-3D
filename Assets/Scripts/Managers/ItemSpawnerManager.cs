using UnityEngine;
using Yashlan.item;
using Yashlan.player;

namespace Yashlan.manage
{
    //fitur tambahan
    public class ItemSpawnerManager : MonoBehaviour
    {
        public float delaySpawn;
        public GameObject itemHP;
        public GameObject itemPU;
        public Transform[] spawnPos;
        public Transform[] spawnPos2;

        PlayerHealth playerHealth;

        void Start()
        {
            //mencari component playerhealth pada gameObject yg ber-tag Player
            playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

            //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
            InvokeRepeating(nameof(SpawnHp), delaySpawn, delaySpawn);
            InvokeRepeating(nameof(SpawnPU), delaySpawn, delaySpawn);
        }

        private void SpawnHp()
        {
            //akan ngespawn jika item health kosong/ tidak ada di scene
            if(FindObjectOfType<ItemHealth>() == null)
            {
                //Jika player telah mati maka tidak membuat spawn
                if (playerHealth.currentHealth <= 0f) return;

                //Mendapatkan nilai random
                int Spawnindex = Random.Range(0, spawnPos.Length);

                //duplikasi item 
                Instantiate(itemHP, spawnPos[Spawnindex].position, itemHP.transform.rotation);
            }
        }

        private void SpawnPU()
        {
            //akan ngespawn jika item power up kosong/ tidak ada di scene
            if (FindObjectOfType<ItemPowerUp>() == null)
            {
                //Jika player telah mati maka tidak membuat spawn
                if (playerHealth.currentHealth <= 0f) return;

                //Mendapatkan nilai random
                int Spawn2index = Random.Range(0, spawnPos2.Length);

                //duplikasi item 
                Instantiate(itemPU, spawnPos2[Spawn2index].position, itemPU.transform.rotation);
            }
        }
    }
}
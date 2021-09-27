using UnityEngine;
using Yashlan.player;

namespace Yashlan.manage
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject enemy;
        public float spawnTime = 3f;
        public Transform[] spawnPoints;

        private PlayerHealth playerHealth;
        private EnemyFactory factory;

        void Start()
        {
            //mengambil enemyfactory component di gameObject
            factory = GetComponent<EnemyFactory>();

            //mencari component playerhealth pada gameObject yg ber-tag Player
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

            //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
            InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
        }


        private void Spawn()
        {
            //Jika player telah mati maka tidak membuat enemy baru
            if (playerHealth.currentHealth <= 0f) return;

            //Mendapatkan nilai random
            int spawnEnemy = Random.Range(0, 3);

            //Menduplikasi enemy pakai factory pattern
            factory.FactoryMethod(spawnEnemy);
        }
    }
}
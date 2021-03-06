using UnityEngine;
using UnityEngine.AI;
using Yashlan.player;

namespace Yashlan.enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public int speed;
        Transform player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        NavMeshAgent nav;


        void Awake()
        {
            //Cari game object dengan tag player
            player = GameObject.FindWithTag("Player").transform;

            //Mendapatkan Reference component
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<NavMeshAgent>();

            //set speed 
            nav.speed = speed;
        }


        void Update()
        {
            //Memindahkan posisi player
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
                nav.SetDestination(player.position);
            else //Hentikan moving
                nav.enabled = false;
        }
    }
}

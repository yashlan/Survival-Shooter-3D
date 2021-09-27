using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yashlan.player;

namespace Yashlan.manage
{
    public class GameOverManager : MonoBehaviour
    {
        public Text warningText;
        public PlayerHealth playerHealth;
        public float restartDelay = 5f;


        Animator anim;
        float restartTimer;

                        //mengambil component animator
        void Awake() => anim = GetComponent<Animator>();

        void Update()
        {
            if (playerHealth.currentHealth <= 0)
            {
                //ganti state anim
                anim.SetTrigger("GameOver");

                //reatart timer bertambah
                restartTimer += Time.deltaTime;

                //jika restrart timer >= 5 maka akan reload scene
                if (restartTimer >= restartDelay)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //set trigger animator player ke warning
        public void ShowWarning(float enemyDistance)
        {
            warningText.text = string.Format("{0}m!", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");
        }
    }
}
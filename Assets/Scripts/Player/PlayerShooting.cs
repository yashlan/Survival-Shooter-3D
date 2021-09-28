using System.Collections;
using UnityEngine;
using Yashlan.enemy;
using Yashlan.manage;

namespace Yashlan.player
{
    public class PlayerShooting : MonoBehaviour
    {
        public bool powerUp = false;
        public int damagePerShot = 20;
        public float timeBetweenBullets = 0.15f;
        public float range = 100f;

        int _damagePerShot;
        float _timeBetweenBullets;
        float _range;

        float timer;
        float powerUpTimer;
        Ray shootRay = new Ray();
        RaycastHit shootHit;
        int shootableMask;
        ParticleSystem gunParticles;
        LineRenderer gunLine;
        AudioSource gunAudio;
        Light gunLight;
        float effectsDisplayTime = 0.2f;

        PlayerHealth playerHealth;
        PlayerMovement playerMove;

        void Awake()
        {
            //GetMask
            shootableMask = LayerMask.GetMask("Shootable");

            //Mendapatkan Reference component
            gunParticles = GetComponent<ParticleSystem>();
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            playerHealth = GetComponentInParent<PlayerHealth>();
            playerMove = GetComponentInParent<PlayerMovement>();

            //dapatkan value awal dari komponen, gunanya untuk mereset ketika powerUp false
            _damagePerShot = damagePerShot;
            _timeBetweenBullets = timeBetweenBullets;
            _range = range;
        }


        void Update()
        {
            if(playerHealth.currentHealth > 0)
            {
                timer += Time.deltaTime;

                if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
                {
                    Shoot();
                }

                if (timer >= timeBetweenBullets * effectsDisplayTime)
                {
                    DisableEffects();
                }
            }

            if (powerUp)
                ScoreManager.Instance.SetTextPowerUp(powerUpTimer -= Time.deltaTime);
        }


        public void DisableEffects()
        {
            //disable line renderer
            gunLine.enabled = false;

            //disable light
            gunLight.enabled = false;
        }

        //set power up
        public void PowerUp(float time, float playerSpeed, int damage, float timeBullets, float range_)
        {
            //stop coroutine terlebih dahulu untuk mereset ketika bercollision dengan item power up
            StopAllCoroutines();
            StartCoroutine(InitPowerUp(time, playerSpeed, damage, timeBullets, range_));
        }

        IEnumerator InitPowerUp(float time, float playerSpeed, int damage, float timeBullets, float range_)
        {
            if (playerHealth.currentHealth <= 0) yield break;
            //ubah semua artibut saat power up true
            powerUp = true;
            powerUpTimer = time;
            damagePerShot = damage;
            playerMove.speed = playerSpeed;
            timeBetweenBullets = timeBullets;
            range = range_;
            gunLight.intensity = 4;
            gunLine.widthMultiplier = 0.2f;
            yield return new WaitForSeconds(time);
            //reset semua artibut saat power up false
            powerUp = false;
            damagePerShot = _damagePerShot;
            playerMove.speed = 6f;
            timeBetweenBullets = _timeBetweenBullets;
            range = _range;
            gunLight.intensity = 1;
            gunLine.widthMultiplier = 0.05f;
            yield break;
        }


        public void Shoot()
        {
            timer = 0f;

            //Play audio
            gunAudio.Play();

            //enable Light
            gunLight.enabled = true;

            //Play gun particle
            gunParticles.Stop();
            gunParticles.Play();

            //enable Line renderer dan set first position
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            //Set posisi ray shoot dan direction
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            //Lakukan raycast jika mendeteksi id nemy hit apapun
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                //Lakukan raycast hit hace component Enemyhealth
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    //Lakukan Take Damage
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                //Set line end position ke hit position
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                //set line end position ke range from barrel
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}
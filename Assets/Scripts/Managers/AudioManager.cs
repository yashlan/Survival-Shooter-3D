using UnityEngine;
using Yashlan.util;

namespace Yashlan.manage
{
    //fitur tambahan
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("BGM")]
        public AudioClip bgmSound;
        [Range(0, 1)]
        public float _bgmVolume;

        [Header("SFX")]
        public AudioSource audioSource;

        private AudioSource _bgmSource;

        void Start()
        {
            //menambahkan component audio source baru untuk bgm music
            _bgmSource = gameObject.AddComponent<AudioSource>();
            _bgmSource.clip = bgmSound;
            _bgmSource.loop = true;
            _bgmSource.volume = _bgmVolume;
            _bgmSource.Play();
        }

        public void PlaySFX(AudioClip sfx)
        {
            if (sfx == null)
                Debug.LogError("NullException : no AudioClip");
            else
                audioSource.PlayOneShot(sfx);
        }
    }
}
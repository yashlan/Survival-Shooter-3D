using UnityEngine;

namespace Yashlan.item
{
    //fitur tamabahan
    public class Item : MonoBehaviour
    {
        public AudioClip collectSound;
        public bool AutoDestroy;
        public int destroyTime;

        void Start()
        {
            //destroy otomatis jika autodestroy true dan tidak bercollision dengan player selema destroytime
            if (AutoDestroy) Destroy(gameObject, destroyTime);
        }
    }
}
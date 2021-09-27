using UnityEngine;

namespace Yashlan.camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothing = 5f;
        Vector3 offset;

        //Mendapatkan offset antara target dan camera
        void Start() => offset = transform.position - target.position;

        void FixedUpdate()
        {
            //Menapatkan posisi untuk camera
            Vector3 targetCamPos = target.position + offset;

            //set posisi camera dengan smoothing
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
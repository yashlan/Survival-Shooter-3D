using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Yashlan.util;

namespace Yashlan.ui
{
    //fitur tambahan
    public class TextInfoUI : Singleton<TextInfoUI>
    {
        public Text textInfo;

        void Start() => textInfo.gameObject.SetActive(false);

        public void ShowTextInfo(string msg, Color color)
        {
            StopAllCoroutines();
            StartCoroutine(Show(msg, color));
        }

        private IEnumerator Show(string msg, Color color)
        {
            textInfo.text = msg;
            textInfo.color = color;
            textInfo.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            textInfo.gameObject.SetActive(false);
            yield break;
        }
    }
}
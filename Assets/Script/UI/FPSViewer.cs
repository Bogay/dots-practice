using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace Bogay.VampireSurvivorLike.UI
{
    public class FPSViewer : MonoBehaviour
    {
        private Text fps;

        IEnumerator Start()
        {
            this.fps = GetComponent<Text>();
            while (true)
            {
                var deltaTime = Time.deltaTime;
                this.fps.text = $"FPS: {Mathf.Floor(1f / deltaTime)}";
                yield return new WaitForSeconds(1);
            }
        }
    }
}

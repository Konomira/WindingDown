using System.Collections;
using UnityEngine;

namespace Camera
{
    public class CameraShake : MonoBehaviour
    {
        private void Update()
        {
            if (Random.Range(0, 100) == 0)
                Shake();
        }

        private Coroutine shakeRoutine;
        private void Shake()
        {
            if(shakeRoutine == null)
                shakeRoutine = StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            var tr = transform;
            for (var i = 0; i < 30; i++)
            {
                var shakePos = transform.right * Random.Range(-0.03f, 0.03f) + transform.up * Random.Range(-0.03f, 0.03f);
            
                tr.position += shakePos;
                yield return new WaitForSeconds(0.05f);
                tr.position -= shakePos;
            }
        
            shakeRoutine = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

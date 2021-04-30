using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDestroy : MonoBehaviour
{
   private float moveSpeed = 10f;

   private bool enableDestroy = false;

   // Update is called once per frame
   void Update()
   {
      if (enableDestroy) transform.Translate(transform.up * moveSpeed * Time.deltaTime);
   }

   private float RandDeg => UnityEngine.Random.Range(-180f, 181f);

   public void DestroyStep()
   {
      transform.Rotate(RandDeg, RandDeg, RandDeg);
      enableDestroy = true;

      Invoke(nameof(DestroyGO), 10f);
   }

   void DestroyGO()
   {
      Destroy(gameObject);
   }
}

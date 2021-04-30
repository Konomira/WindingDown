using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCamera : MonoBehaviour
{
   public Transform playerTr;

   private void OnEnable() {
      Debug.Log("enabled");
      transform.position = GameObject.FindWithTag("Ground").transform.GetChild(0).transform.localPosition;
      Debug.Log("pos" + transform.position);
   }

   // Update is called once per frame
   void Update()
   {
      transform.LookAt(playerTr);
   }
}

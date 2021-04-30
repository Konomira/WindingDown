using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Steps
{
   public class StepGenerator : MonoBehaviour
   {
      public int stepCount = 540;
      public float stepHeight;

      public float rotateSpeed;

      public Transform root;

      public GameObject stepPrefab;

      private List<GameObject> steps = new List<GameObject>();
      public float stepToPlayerOffset = 2.5f; // decreases every time the player hits a barrel
      public GameObject player;
      public GameObject groundPrefab;

      // Start is called before the first frame update

      void Start()
      {
         GenerateSteps();
      }

      void GenerateSteps()
      {
         Debug.Log("generating steps");
         for (var i = 0; i < stepCount; i++)
         {
            var stepPos = root.position - Vector3.up * stepHeight * i;
            var go = Instantiate(stepPrefab, stepPos, Quaternion.identity);
            go.transform.parent = root;
            go.transform.Rotate(Vector3.up, 10 * i);
            steps.Add(go);
         }

         Instantiate(groundPrefab, steps[steps.Count - 1].transform.position, Quaternion.identity);
         Player.PlayerMover.OnBarrelHit = () => stepToPlayerOffset -= .1f;

         // steps gets destroyed shortly after they are created
         StartCoroutine(PrepareStepsToDestroy());
      }

      // Update is called once per frame
      void Update()
      {

         foreach (var step in steps)
         {
            if (step.transform.parent)
               step.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
         }
      }

      IEnumerator PrepareStepsToDestroy()
      {
         int i = 0;

         for (; ; )
         {

            Vector3 stepPos = steps[i].transform.position;
            Vector3 playerPos = player.transform.position;

            //Debug.Log("fc: " + Time.frameCount + " i " + i + Mathf.Abs(Vector3.Distance(stepPos, playerPos)));

            // game over

            if (
               stepPos.y > playerPos.y
               && Mathf.Abs(Vector3.Distance(stepPos, playerPos)) > stepToPlayerOffset
               || stepToPlayerOffset <= 0 /* <- game over */)
            {
               steps[i].transform.parent = null;
               steps[i].GetComponentInChildren<StepDestroy>().DestroyStep();

               steps.RemoveAt(i);
            }

            if (steps.Count == 0) break;

            if (stepToPlayerOffset <= 0) yield return null; else yield return new WaitForSeconds(0.2f);
         }
      }
   }
}


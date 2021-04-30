using System.Collections.Generic;
using UnityEngine;

namespace Steps
{
   public class BarrelGenerator : MonoBehaviour
   {

      // external properties
      public StepGenerator stepGenerator;
      float stepHeight;
      float rotateSpeed;
      Transform root;


      // Barrels
      public GameObject barrelPrefab;
      private List<GameObject> barrels = new List<GameObject>();
      private List<float> spawnPos = new List<float> { -.15f, -.4f, -.8f };

      // Start is called before the first frame update
      void Start()
      {
         GenerateBarrels();
      }

      void GenerateBarrels()
      {
         // get stepgenerator config
         root = stepGenerator.root;
         rotateSpeed = stepGenerator.rotateSpeed;
         stepHeight = stepGenerator.stepHeight;

         var barrelInterval = 0;
         for (var i = 0; i < stepGenerator.stepCount; i++)
         {
            var stepPos = root.position - Vector3.up * stepHeight * i;

            // barrel generator
            barrelInterval++;
            if (barrelInterval > (int)Random.Range(1, 4))
            {
               barrelInterval = 0; // reset

               GameObject barrel = Instantiate(barrelPrefab, stepPos, Quaternion.identity);
               barrel.transform.parent = root;
               barrel.transform.GetChild(0).transform.localPosition = new Vector3(spawnPos[(int)Random.Range(0, spawnPos.Count)], .47f, 1);
               barrel.transform.Rotate(Vector3.up, 10 * i);
               barrels.Add(barrel);
            }
         }
      }

      // Update is called once per frame
      void Update()
      {
         foreach (var barrel in barrels)
            barrel.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
      }

   }
}

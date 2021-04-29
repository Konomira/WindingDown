using System.Collections.Generic;
using UnityEngine;

namespace Steps
{
    public class StepGenerator : MonoBehaviour
    {
        public int stepCount;
        public float stepHeight;

        public float rotateSpeed;
    
    
        public Transform root;
    
        public GameObject stepPrefab;

        public UnityEngine.Camera wideViewCamera;
    
    
        private List<GameObject> steps = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {
            for (var i = 0; i < stepCount; i++)
            {
                var go = Instantiate(stepPrefab, root.position - Vector3.up * stepHeight * i, Quaternion.identity);
                go.transform.parent = root;
                go.transform.Rotate(Vector3.up, 10 * i);
                steps.Add(go);
                var tr = wideViewCamera.transform;
                var pos = tr.position;
                pos.y = -stepCount * 0.5f * stepHeight;
                tr.position = pos;
                wideViewCamera.orthographicSize = stepCount * 0.5f * stepHeight;
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var step in steps) 
                step.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }
}

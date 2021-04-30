using UnityEngine;
using System;

namespace Player
{
   public class PlayerMover : MonoBehaviour
   {

      public static Action<int> OnHealthChange;

      int health = 300;
      public float fallSpeed;
      public Transform playerVisual;

      private int pos = 1;
      private ParticleSystem particleSys;

      public static Action OnBarrelHit;

      public GameObject playerCam;
      private bool healthSet = false;
      public static bool finished = false;
      public GameObject finishCamera;

      public AudioSource othersfx;
      public AudioSource playersfx;

      // called by gamemanager before game starts
      public void Start()
      {
         particleSys = gameObject.GetComponentInChildren<ParticleSystem>();
         othersfx = GameObject.Find("OtherSFX").GetComponent<AudioSource>();
         playersfx = GameObject.Find("PlayerSFX").GetComponent<AudioSource>();
      }

      private void OnTriggerEnter(Collider other)
      {
         if (other.tag == "Barrel")
         {
            health--;
            OnHealthChange.Invoke(health);
            OnBarrelHit.Invoke();
            particleSys.Play();
            othersfx.Play();
         }
         else if (other.tag == "Ground") // win
         {
            playerCam.SetActive(false);
            finishCamera.SetActive(true);
            transform.Rotate(-45f, 0, 0);
            playersfx.Play();
            GameObject.Find("Canvas").GetComponent<InGameUI>().WonUIEffect();
            //InvokeRepeating(nameof(FinalDanceMove), 13f, .5f); bugs the audio player for some reason
            finished = true;
         }
      }

      void FinalDanceMove()
      {
         transform.Rotate(UnityEngine.Random.Range(-180, 181), UnityEngine.Random.Range(-180, 181), UnityEngine.Random.Range(-180, 181));
      }

      void Update()
      {
         if (!finished)
         {
            transform.position += Vector3.down * (fallSpeed * Time.deltaTime);
         }
         else
         {
            transform.Translate(Vector3.forward * 8f * Time.deltaTime);
            return;
         }

         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
            if (pos <= 0) return;

            var oldPos = playerVisual.position;
            pos--;
            switch (pos)
            {
               case 0:
                  oldPos.x = 1.0f;
                  break;
               case 1:
                  oldPos.x = 0.3f;
                  break;
            }

            playerVisual.position = oldPos;
         }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
         {
            if (pos >= 2) return;

            var oldPos = playerVisual.position;
            pos++;

            switch (pos)
            {
               case 1:
                  oldPos.x = 0.3f;
                  break;
               case 2:
                  oldPos.x = -0.4f;
                  break;
            }

            playerVisual.position = oldPos;
         }
      }
   }
}

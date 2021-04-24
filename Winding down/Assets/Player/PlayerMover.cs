using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        public float fallSpeed;
        public Transform playerVisual;

        private int pos = 1;
        void Update()
        {
            transform.position += Vector3.down * (fallSpeed * Time.deltaTime);

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

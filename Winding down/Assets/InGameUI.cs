using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
   public Text healthText;

   public Text wonText;
   public GameObject wonTextGO;

   // Start is called before the first frame update
   public void Start()
   {
      Player.PlayerMover.OnHealthChange = (health) => healthText.text = health.ToString();
   }

   public void WonUIEffect()
   {
      wonTextGO.SetActive(true);
   }

   private void Update()
   {
      if (Player.PlayerMover.finished)
      {
         wonText.rectTransform.localPosition = new Vector3(Random.Range(8, -8), Random.Range(-12, -25), 0);
      }
   }
}

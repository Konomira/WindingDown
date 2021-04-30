using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
   public Button startGameBtn;
   // Start is called before the first frame update
   void Start()
   {
      startGameBtn.onClick.AddListener(() => { SceneManager.LoadScene(1); });
   }
}

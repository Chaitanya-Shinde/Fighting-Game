using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
     public RoundManager RM;
     public PauseMenu PM;

     void Update() {
          RM = GameObject.Find("GameManager").GetComponent<RoundManager>();
          //PM = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
     }
     public void PlayGame()
     {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
          
          RM.onlyOnce = true;
          RM.restartOnce = true;
          RM.currentTime = 3.5f;
          RM.playerWinCount = 0;
          RM.enemyWinCount = 0;
          //RM.pauseAnim.Play("pauseMenuUP");
          FindObjectOfType<AudioManager>().Play("CountDown");
          RM.pauseAnim.SetBool("OnPause", false);
          
          //PM.once = true;

     }

     public void QuitGame()
     {
          Application.Quit();
     }

   
}

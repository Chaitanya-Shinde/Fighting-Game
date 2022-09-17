using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class RestartMenu : MonoBehaviour
{

    public RoundManager RM;
    //private bool restartOnce;

    public static RestartMenu _RestartMenu;
    public GameObject restartMenu;

    
    void Awake() 
    {
        if (_RestartMenu != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_RestartMenu = this;
			DontDestroyOnLoad(gameObject);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        //restartOnce = true;
        RM = GameObject.Find("GameManager").GetComponent<RoundManager>();
        restartMenu = GameObject.Find("RestartMenu");
        RM.pauseAnim.SetBool("OnPause", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
    }

    public void RestartGame()
    {
        if(RM.restartOnce == true)
        {
            
            RM.restartAnim.SetBool("OnRestart", false); 
            RM.restartOnce = false;
            RM.playerWinCount = 0;
            RM.onlyOnce = true;
            RM.currentTime = 3.5f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            
        }

       
    }

    public void MainMenu(int sceneID)
    {
        
        //pauseAnim.Play("pauseMenuUP");
        RM.pauseAnim.SetBool("OnPause",false);
        RM.restartAnim.SetBool("OnRestart", false);
        StartCoroutine(RestartUP(2));
        SceneManager.LoadScene(sceneID);
        
    }

    IEnumerator RestartUP(int secs)
    {
        
        // RM.restartAnim.Play("restartMenuUP");
        
        yield return new WaitForSeconds(secs);
        Debug.Log("restart up");
        
        
    }
    IEnumerator RestartDOWN()
    {
        RM.restartAnim.SetBool("OnRestart", true);
        yield return new WaitForSeconds(0.5f);
    }

    

}

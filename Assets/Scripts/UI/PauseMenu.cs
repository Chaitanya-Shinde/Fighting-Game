using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static PauseMenu _PauseMenu;
    
    public Animator pauseAnim;
    public RoundManager RM;
    public bool once = true, pauseOnce = true, isPaused = false;
    // Start is called before the first frame update

    void Awake() 
    {
        if (_PauseMenu != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_PauseMenu = this;
			DontDestroyOnLoad(gameObject);
        } 
    }
    void Start()
    {
        RM = GameObject.Find("GameManager").GetComponent<RoundManager>();
        
    }

    void Update() 
    {
        if(once)
        {
            //PauseStart();
            pauseMenu = GameObject.Find("PauseMenu");
            //Resume();
            //once = false;
        }
        pauseAnim = GameObject.Find("PauseMenu").GetComponent<Animator>();
        if(Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            StartCoroutine(Pause());
            isPaused = true;

               
        }
        

        Debug.Log(Time.timeScale);



    }

    IEnumerator Pause()
    {
        //pauseMenu.SetActive(true);
        // pauseAnim.Play("pauseMenuDOWN");
        pauseAnim.SetBool("OnPause", true);
        isPaused = true;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        

        if(Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            Time.timeScale = 1f;
            pauseAnim.SetBool("OnPause", false);
            isPaused = false;
            
        } 
        
  
    }

    public void Resume() //onClick
    {
        //pauseMenu.SetActive(false);
        //pauseAnim.Play("pauseMenuUP");
        pauseAnim.SetBool("OnPause", false);
        pauseOnce = true;
        isPaused = false;
        Time.timeScale = 1f;
    }

    

    public void PauseStart()
    {
        //pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Mainmenu(int sceneID) //onClick
    {
        //once = true;
       
        Time.timeScale =1f;
        //pauseAnim.Play("pauseMenuUP");
        SceneManager.LoadScene(sceneID);

    }

    // public void PauseUP()
    // {
    //     pauseAnim.Play("pauseMenuUP");
    // }
    // public void PauseDOWN()
    // {
        
    // }
}

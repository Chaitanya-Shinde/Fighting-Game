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
    public bool once = true, pauseOnce = true;
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
        StartCoroutine(Pause());

        Debug.Log(Time.timeScale);



    }

    IEnumerator Pause()
    {
       
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(pauseOnce)
            {
                //pauseMenu.SetActive(true);
                // pauseAnim.Play("pauseMenuDOWN");
                pauseAnim.SetBool("OnPause", true);
                pauseOnce = false;
                yield return new WaitForSeconds(0.5f);
                Time.timeScale = 0f;
 
            }
            else
            {
                Time.timeScale = 1f;
            }
            
  
            if(Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 1f;
                pauseAnim.SetBool("OnPause", false);
                pauseOnce = true;
                
            }
            
            
        }
            
        
        
    }

    public void Resume() //onClick
    {
        //pauseMenu.SetActive(false);
        //pauseAnim.Play("pauseMenuUP");
        pauseAnim.SetBool("OnPause", false);
        pauseOnce = true;
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

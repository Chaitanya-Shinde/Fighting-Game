using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public Restart _restartmatch;
    public static RoundManager instance;
    public static TMP_Text cdText_Instance;
    public int roundsCount = 3, round = 0, playerWinCount = 0,enemyWinCount = 0;
    public bool onlyOnce = true, restartOnce;
    private float ReloadTime =2.0f;
    public float currentTime = 0f,startTime = 3f, transTime = 1f;
    [SerializeField] private TMP_Text CountDownText;
    [SerializeField] private TMP_Text PlayerWinText, EnemyWinText;
    public Image P1, P2, E1, E2;
    Color temp,fill = new Color(1,1,1,1);
    Color32 zeroAlpha = new Color32 (0,0,0,0);
    public HealthScript healthScriptPlayer, healthScriptEnemy;
    public GameObject textobj;
    [SerializeField] GameObject pauseMenu;

    public PauseMenu pauseScript;
    public UIAnimationDelegate uiAnim;
    public GameDelegate GD;
    public Animator winAnim, pauseAnim,restartAnim, transAnim;
    public CharacterAnimationDelegate CD;
    // Start is called before the first frame update

    void Awake() 
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
        }
        //CheckTimerInstances();
    }
    void Start()
    {
        playerWinCount = 0;
        enemyWinCount = 0;
        onlyOnce = true;
        restartOnce = true;
        //_restartmatch.restart = false;
        temp.a = 0.0f;
        fill.a = 1.0f;
        
        //pauseMenu = GameObject.Find("PauseMenu");
        // PlayerWinText.alpha = 0;
        // EnemyWinText.alpha = 1;

        //PlayerWinText.color = zeroAlpha;
        currentTime = startTime;    
        pauseScript.enabled = true;
        pauseAnim.SetBool("OnPause", false);
        restartAnim.SetBool("OnRestart", false);
        //restartOnce = false;
       
        // uiAnim = GameObject.FindWithTag("3").GetComponent<UIAnimationDelegate>();
        

        // GD.DisablePLayerAttack();
        // GD.DisablePlayerMovement();
        // GD.DisablePLayerAttack();
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        healthScriptPlayer = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<HealthScript>();
        healthScriptEnemy = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<HealthScript>();
        textobj = GameObject.FindWithTag("CountDownTextUI");
        GD = GetComponent<GameDelegate>();
        winAnim = GameObject.Find("Win Text").GetComponent<Animator>();
        CD = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<CharacterAnimationDelegate>();
        CountDownText = textobj.GetComponent<TMP_Text>();
        PlayerWinText = GameObject.Find("PlayerWin").GetComponent<TMP_Text>();
        EnemyWinText = GameObject.Find("EnemyWin").GetComponent<TMP_Text>();
        pauseMenu = GameObject.Find("PauseMenu");
        pauseScript = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
        pauseAnim = GameObject.Find("PauseMenu").GetComponent<Animator>();
        restartAnim = GameObject.Find("RestartMenu").GetComponent<Animator>();
        transAnim = GameObject.Find("FadeTrans").GetComponent<Animator>();

        P1 = GameObject.Find("P1").GetComponent<Image>();
        P2 = GameObject.Find("P2").GetComponent<Image>();
        E1 = GameObject.Find("E1").GetComponent<Image>();
        E2 = GameObject.Find("E2").GetComponent<Image>();


        StartCoroutine(CheckRoundCount());
        Countdown();
        WinIndicators();
        // StartCoroutine(Pause());
        CheckBuildInstance();
        //Debug.Log(healthScriptEnemy.health);
        //Debug.Log(healthScriptPlayer.health);

        StartNextRound();

        
        
        // if(_restartmatch.restart && restartOnce == false)
        // {
            
        //     restartAnim.SetBool("OnRestart", true);
            
        // }
        // else{

        //     restartAnim.SetBool("OnRestart", false);
        // }

        // if(playerWinCount ==2 || enemyWinCount ==2)
        // {
        //     playerWinCount = 0;
        //     enemyWinCount = 0;
        //     LoadMainMenu();
        // }


    }

    public void PlayerWin()
    {
        //increment player win count
        playerWinCount++;
        round++;
    }

    public void EnemyWin()
    {
        //increment enemy win count
        enemyWinCount++;
        round++;
    }

    IEnumerator CheckRoundCount()
    {
        //if player/enemy win count is 2 then stop game, player/enemy win
        
        // if(playerWinCount ==2 || enemyWinCount ==2)
        // {
            
            if(playerWinCount ==2)
            {
                
                PlayerWinText.alpha =1;
                winAnim.Play("PlayerWin");
                yield return new WaitForSeconds(3f);
                PlayerWinText.alpha = 0;
                healthScriptEnemy.health = healthScriptEnemy.maxHealth;
                healthScriptPlayer.health = healthScriptPlayer.maxHealth;
                yield return new WaitForSeconds(transTime);
                playerWinCount = 0;
                enemyWinCount = 0;
                if(restartOnce){
                    LoadMainMenu();
                    restartOnce = false;
                }
                
                
                
                
                
                
            }
            else if(enemyWinCount ==2)
            {
                
                EnemyWinText.alpha = 1;
                winAnim.Play("EnemyWin");
                yield return new WaitForSeconds(3f);
                EnemyWinText.alpha = 0;
                playerWinCount = 0;
                enemyWinCount = 0;
                healthScriptEnemy.health = healthScriptEnemy.maxHealth;
                healthScriptPlayer.health = healthScriptPlayer.maxHealth;
                yield return new WaitForSeconds(transTime);
                if(restartOnce){
                    LoadMainMenu();
                    restartOnce = false;
                }
                
                
            }
            
        // }
        
        
    }

    public void Countdown()
    {
        if(onlyOnce)
        {
            
            if(currentTime>0 && SceneManager.GetActiveScene().buildIndex == 1)
            {
                
                currentTime -= 1 * Time.deltaTime;
                //print (currentTime);
                CountDownText.text = currentTime.ToString ("         0");
                if(CountDownText.text == "         0")
                {
                    CountDownText.text = "Fight";
                    
                }
                if(CountDownText.text =="Fight")
                {
                    StartCoroutine(WaitForAWhile());
                    
                }
                
            }
            if(currentTime <=0)
            {
                currentTime = 0;
                
                //CountDownText.text = "FIGHT";
                StartRound();
                onlyOnce = false;
            }
            // if(currentTime>=3.5f){CountDownText.color = Color.black;}
            // if(currentTime<3.5f){CountDownText.color = Color.red;}
       
            // else
            // {
            //     currentTime = startTime;
            //     Debug.Log("MainMenu");   
            // }

        }     
    }

    public void StartRound()
    {
        //enable movement and attack
        
    }

    public void StartNextRound()
    {
        //Debug.Log(round);
        
        if(healthScriptEnemy.health==0 )
        {
            Debug.Log("Enemy died");
            //reload the level
            PlayerWin();
            
            
            if(playerWinCount <=1 && enemyWinCount <=1)
            {
                StartCoroutine(ReloadLevel());
                
            }
            healthScriptEnemy.health = healthScriptEnemy.maxHealth;
            healthScriptPlayer.health = healthScriptPlayer.maxHealth;
            
  
        }
        else if(healthScriptPlayer.health==0)
        {
            Debug.Log("Player died");
            //reload the level
            EnemyWin();
            //CheckRoundCount();
            if(playerWinCount <=1 && enemyWinCount <=1)
            {
                StartCoroutine(ReloadLevel());
                
            }
            healthScriptEnemy.health = healthScriptEnemy.maxHealth;
            healthScriptPlayer.health = healthScriptPlayer.maxHealth;
            
           
        }
        
        

        

    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(ReloadTime);   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        pauseAnim.Play("pauseMenuUP");
        //uiAnim.img3.SetActive(true);
        currentTime = startTime;
        onlyOnce = true;
        Countdown();
        Debug.Log("CountDown started");
        //play countdown sound
        FindObjectOfType<AudioManager>().Play("CountDown");
        Time.timeScale = 1;

        
           
    }

    IEnumerator WaitForAWhile()
    {
        yield return new WaitForSeconds(1f);
        CountDownText.text = " ";
        GD.EnableEnemyMovement();
        GD.EnablePlayerMovement();
        GD.EnablePlayerAttack();
 
    }

    void CheckTimerInstances()
    {
        if (cdText_Instance != null)
		{
			Destroy(textobj);
		}
		else
		{
			cdText_Instance = CountDownText;
			DontDestroyOnLoad(textobj);
		}
    }


    void WinIndicators()
    {
        switch (playerWinCount)
        {
            case 0:
                P1.color = temp;
                P2.color = temp;
                break;
            case 1:
                P1.color = fill;
                P2.color = temp;
                break;
            case 2:
                P2.color = fill;
                break;

            default:
                P1.color = temp;
                P2.color = temp;
                break;
        }

        switch (enemyWinCount)
        {
            case 0:
                E1.color = temp;
                E2.color = temp;
                break;
            case 1:
                E1.color = fill;
                E2.color = temp;
                break;
            case 2:
                E2.color = fill;
                break;

            default:
                E1.color = temp;
                E2.color = temp;
                break;
        }
    }



    void CheckBuildInstance()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentTime = startTime;
            Debug.Log("MainMenu");          
        }    
    }

    void LoadMainMenu() //loads credits scene
    {
        StartCoroutine(LoadMain());
    }

    IEnumerator LoadMain() //loads credits scene
    {
        Debug.Log("change scene");
        transAnim.SetTrigger("OnFade");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(2);

    }

    
}

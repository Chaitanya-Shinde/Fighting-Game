using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;
    public static TMP_Text cdText_Instance;
    public int roundsCount = 3;
    public int round = 0;
    public int playerWinCount = 0;
    public int enemyWinCount = 0;
    private float ReloadTime =2.0f;
    public float currentTime = 0f;
    public float startTime = 10f;
    [SerializeField] private TMP_Text CountDownText;

    public HealthScript healthScriptPlayer;
    public HealthScript healthScriptEnemy;
    public GameObject textobj;
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
        currentTime = startTime;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        healthScriptPlayer = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<HealthScript>();
        healthScriptEnemy = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<HealthScript>();
        textobj = GameObject.FindWithTag("CountDownTextUI");
        CountDownText = textobj.GetComponent<TMP_Text>();
        //Countdown();
        //Debug.Log(healthScriptEnemy.health);
        //Debug.Log(healthScriptPlayer.health);

        
        StartNextRound();
        //CheckRoundCount();

        //player/enemy win
        //Debug.Log("WINNN");
        StartNextRound();
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

    public void CheckRoundCount()
    {
        //if player/enemy win count is 2 then stop game, player/enemy win
        //if()
        if(playerWinCount ==2 || enemyWinCount ==2)
        {
            
            //player/enemy win
            Debug.Log("WINNN");
            
        }
        else
        {
            StartNextRound();
        }
        
    }

    public void Countdown()
    {
    
        if(currentTime>0)
        {
            currentTime -= 1 * Time.deltaTime;
            //print (currentTime);
            CountDownText.text = currentTime.ToString ("0");
        }
        if(currentTime <=0)
        {
            currentTime = 0;
            StartRound();
        }

        // if(currentTime>=3.5f){CountDownText.color = Color.black;}
        // if(currentTime<3.5f){CountDownText.color = Color.red;}
    }

    public void StartRound()
    {
        //enable movement and attack

    }

    public void StartNextRound()
    {
        Debug.Log(round);
        
        if(healthScriptEnemy.health==0 )
        {
            Debug.Log("Enemy died");
            //reload the level
            PlayerWin();
            //CheckRoundCount();
            
            if(playerWinCount <=2 && enemyWinCount <=2)
            {
                StartCoroutine(ReloadLevel());
            }
            else
            {
                Debug.Log("BBB");
            }

            
            healthScriptEnemy.health = healthScriptEnemy.maxHealth;
            healthScriptPlayer.health = healthScriptPlayer.maxHealth;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

            
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
            else
            {
                Debug.Log("AAA");
            }
            
            
            healthScriptEnemy.health = healthScriptEnemy.maxHealth;
            healthScriptPlayer.health = healthScriptPlayer.maxHealth;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
        }
        
        

        

    }

    IEnumerator ReloadLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        yield return new WaitForSeconds(ReloadTime);    
        currentTime = startTime;
        Countdown();
        Debug.Log("CountDown started");

        
           
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

    
}

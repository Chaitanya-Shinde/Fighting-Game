using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    private CharacterAnimation anim;
    private Animator animator;
    private EnemyMovement enemyMovement;
    private bool charaterDied;
    public bool isPlayer;
    //private HealthUI healthUI;
    public Image health_UI, playerHealthUI, enemyHealthUI;


    void Awake() 
    {
        anim = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        playerHealthUI = GameObject.Find("PlayerHealthUI").GetComponent<Image>();
        enemyHealthUI = GameObject.Find("EnemyHealthUI").GetComponent<Image>();
        //healthUI = GetComponent<HealthUI>();
        
        // healthBar.GetComponent<Slider>();
        // healthBar = GetComponent<Healthbar>();
        
    }

    void Start() 
    {
        health = maxHealth;
        
        
    }
    
    public void ApplyDamage(float damage, bool knockDown)
    {
        

        if(charaterDied)
            return;
        
        health -= damage;

        //display health        
        if(isPlayer)
        {
           DisplayHealth(health);
        }
        if(!isPlayer)
        {
            DisplayHealth(health);
        }
        
        

        if(health <= 0)
        {
            anim.Death();
            charaterDied = true;

            if(isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            if(!isPlayer)
            {
                Debug.Log("ENEMY DEAD");
            }
            
            return;
        }

        if(!isPlayer)
        {   
            
            if(knockDown)
            {
                Debug.Log("Knockdown true");
                animator.SetLayerWeight(1,0.0f);
                if(Random.Range(0,2) > 0)
                { 
                    anim.KnockDown();
                }
            }
            else
            {
                Debug.Log("hit");
                if(Random.Range(0,3) > 1)
                { 
                    anim.Hit();
                }
                
            }
        }
        if(isPlayer)
        {  
            if(knockDown)
            {
                Debug.Log("Knockdown true");
                animator.SetLayerWeight(1,0.0f);
                if(Random.Range(0,2) > 0)
                { 
                    anim.KnockDown();
                }
            }
            else
            {
                Debug.Log("hit");
                if(Random.Range(0,3) > 1)
                { 
                    anim.Hit();
                }
                
            }
        }
    }

    public void DisplayHealth(float value)
    {
        value/=100f;
        if(value <0f)
        {
            value = 0f;
        }
        if(isPlayer)
        {
            playerHealthUI.fillAmount = value;
        }
        else if(!isPlayer)
        {
            enemyHealthUI.fillAmount = value;
        }
        
    }

    
}

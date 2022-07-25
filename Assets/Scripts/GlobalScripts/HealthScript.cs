using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation anim;
    private Animator animator;
    private EnemyMovement enemyMovement;
    private bool charaterDied;
    public bool isPlayer;

    void Awake() 
    {
        anim = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();
    }
    
    public void ApplyDamage(float damage, bool knockDown)
    {
        if(charaterDied)
            return;
        
        health -= damage;

        if(health <= 0)
        {
            anim.Death();
            charaterDied = true;

            if(isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
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
}

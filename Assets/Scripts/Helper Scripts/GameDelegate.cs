using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDelegate : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public CharacterAnimation charAnim;
    public PlayerAttack playerAttack;
    public EnemyMovement enemyMovement;
    public Animator anim;
    public Animator enemyAnim;
    private ShakeCamera shakeCamera;

    public void Start() 
    {
        
        

        // DisableEnemyMovement();
        // DisablePlayerMovement();
        // DisablePLayerAttack();

        
        
    }

    public void Update()
    {
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
        characterMovement = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<CharacterMovement>(); 
        enemyMovement = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>();
        charAnim = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<CharacterAnimation>();
        enemyAnim = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<Animator>();
        anim = GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<Animator>();
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();    
    }
    

    public void DisableEnemyMovement()
    {
        enemyMovement.enabled = false;
        enemyAnim.SetLayerWeight(1,0);
        transform.gameObject.layer = 0;
    }
    public void DisablePlayerMovement()
    {
        //playerAttack.enabled = false;
        characterMovement.enabled = false;
        anim.SetLayerWeight(1,0);
        transform.gameObject.layer=0;
    }

    public void EnableEnemyMovement()
    {
        
        //Debug.Log("enable movement");
        enemyMovement.enabled = true;
        
        transform.gameObject.layer = 7;
    }

    public void EnablePlayerMovement()
    {
        Debug.Log("enable player movement");
        //playerAttack.enabled = true;
        characterMovement.enabled = true;
        transform.gameObject.layer = 6;
    }

    public void DisablePLayerAttack()
    {
        playerAttack.enabled = false;
    }

    public void EnablePlayerAttack()
    {
        playerAttack.enabled =true;
    }

    public void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    public void ResetAllPlayerAnimatorTriggers()
    {
        foreach (var trigger in anim.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(trigger.name);
            }
        }
        
    }

    public void ResetAllEnemyAnimatorTriggers()
    {
        foreach (var trigger in enemyAnim.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                enemyAnim.ResetTrigger(trigger.name);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
   
    private CharacterMovement characterMovement;
    private CharacterAnimation charAnim;
    private PlayerAttack playerAttack;
    private EnemyMovement enemyMovement;
    public Animator anim;
    public Animator enemyAnim;
    private ShakeCamera shakeCamera;

    void Start() 
    {
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
        characterMovement = GetComponent<CharacterMovement>(); 
        charAnim = GetComponent<CharacterAnimation>();
        playerAttack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();   

        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponent<EnemyMovement>();
            enemyAnim = GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<Animator>();
        }
        
    }
    

    void leftArmAttackPoint_ON()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void leftArmAttackPoint_OFF()
    {
        if(leftArmAttackPoint.activeInHierarchy)
            leftArmAttackPoint.SetActive(false);
    }

    void rightArmAttackPoint_ON()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void rightArmAttackPoint_OFF()
    {
        if(rightArmAttackPoint.activeInHierarchy)
            rightArmAttackPoint.SetActive(false);
    }

    void leftLegAttackPoint_ON()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void leftLegAttackPoint_OFF()
    {
        if(leftLegAttackPoint.activeInHierarchy)
            leftLegAttackPoint.SetActive(false);
    }

    void rightLegAttackPoint_ON()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void rightLegAttackPoint_OFF()
    {
        if(rightLegAttackPoint.activeInHierarchy)
            rightLegAttackPoint.SetActive(false);
    }

    void TagLeftArm() 
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeftLeg()
    {   
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    void UnTagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagRightArm() 
    {
        rightArmAttackPoint.tag = Tags.RIGHT_ARM_TAG;
    }

    void UnTagRightArm()
    {
        rightArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagRightLeg()
    {
        rightLegAttackPoint.tag = Tags.RIGHT_LEG_TAG;
    }

    void UnTagRightLeg()
    {
        rightLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }


    void JumpBackAnim()
    {
        characterMovement.JumpBack();
        
    }

    void ResetJumpBackTimer()
    {
        characterMovement.ResetJumpBackTimer();
    }

    void DisableEnemyMovement()
    {
        enemyMovement.enabled = false;
       
        anim.SetLayerWeight(1,0);
        transform.gameObject.layer = 0;
    }
    void DisablePlayerMovement()
    {
        //playerAttack.enabled = false;
        characterMovement.enabled = false;
        anim.SetLayerWeight(1,0);
        transform.gameObject.layer=0;
    }

    void EnableEnemyMovement()
    {
        
        //Debug.Log("enable movement");
        enemyMovement.enabled = true;
        
        transform.gameObject.layer = 7;
    }

    void EnablePlayerMovement()
    {
        Debug.Log("enable player movement");
        //playerAttack.enabled = true;
        characterMovement.enabled = true;
        transform.gameObject.layer = 6;
    }

    void DisablePLayerAttack()
    {
        playerAttack.enabled = false;
    }

    void EnablePlayerAttack()
    {
        playerAttack.enabled =true;
    }
    void StandUpAnimation()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
        charAnim.StandUp();
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void ResetAllPlayerAnimatorTriggers()
    {
        foreach (var trigger in anim.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(trigger.name);
            }
        }
        
    }

    void ResetAllEnemyAnimatorTriggers()
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
  
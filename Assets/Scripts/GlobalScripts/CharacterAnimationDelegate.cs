using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
   
    private CharacterMovement characterMovement;

    void Start() 
    {
        characterMovement = GetComponent<CharacterMovement>();    
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
    
}
  
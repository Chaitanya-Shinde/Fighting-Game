using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    
    void Awake() 
    {
        anim = GetComponent<Animator>();
        
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }
    public void Punch_1()
    {
        anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }
    public void Kick_1()
    {
        anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }
    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }
    public void Leg_Sweep()
    {
        anim.SetTrigger(AnimationTags.LEG_SWEEP_TRIGGER);
    }
    public void SweepFall()
    {
        anim.SetTrigger(AnimationTags.SWEEP_FALL);
    }
    public void Jump()
    {
        anim.SetTrigger(AnimationTags.JUMP_ANIMATION);
    }
    public void JumpBack()
    {
        anim.SetTrigger(AnimationTags.JUMP_BACK_TRIGGER);
    }

    //EnemyAnimations

    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
        }
        if(attack == 1)
        {
            anim.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
        }
        if(attack == 2)
        {
            anim.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
        }
        if(attack == 3)
        {
            anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
        }
        if(attack == 4)
        {
            anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
        }
    }

    public void Idle_Animation()
    {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
        //anim.SetBool(AnimationTags.KNOCK_DOWN_BOOL, knockdown);
    }

    public void StandUp()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }
    
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {

        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundDelegate : MonoBehaviour
{
    void Kick1_Sound()
    {
        FindObjectOfType<AudioManager>().Play("Kick1");
    }

    void Kick2_Sound()
    {
        FindObjectOfType<AudioManager>().Play("Kick2");
    }

    void Punch1_Sound()
    {
        FindObjectOfType<AudioManager>().Play("Punch1");
        FindObjectOfType<AudioManager>().Play("PunchShwoosh");
    }

    void CrossPunch_Sound()
    {
        //make chages to crosspunch sound
        FindObjectOfType<AudioManager>().Play("CrossPunch");
        FindObjectOfType<AudioManager>().Play("PunchShwoosh");

    }

    void KnockUp_Sound()
    {
        FindObjectOfType<AudioManager>().Play("KnockUp");
    }

    void FallDown_Sound()
    {
        FindObjectOfType<AudioManager>().Play("FallDown");
        
    }

    void CountDown()
    {
        FindObjectOfType<AudioManager>().Play("CountDown");
    }

    void YouWin()
    {
        FindObjectOfType<AudioManager>().Play("YouWin");
    }

    void YouLose()
    {
        FindObjectOfType<AudioManager>().Play("YouLose");
    }
}

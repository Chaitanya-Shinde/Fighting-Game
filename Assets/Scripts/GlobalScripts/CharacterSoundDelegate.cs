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
}

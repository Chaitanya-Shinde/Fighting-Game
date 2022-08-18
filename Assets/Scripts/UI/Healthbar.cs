using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Healthbar : MonoBehaviour
{
    
    public Slider slider;

    void Awake() 
    {
        
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.highValue = maxHealth;
        slider.value = maxHealth;
    }
    public void SetHealth(float health)
    {
        slider.value = health / 100f;
        if(slider.value <0f)
            slider.value = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBar : Singleton<HUDBar>
{
    public Slider slider;

    public void SetMaxHealth(int health)        //Set vita massima nell'HUD
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)           //Set vita corrente nell'HUD
    {
        slider.value = health;
    }
    public void SetMaxExp(int exp)              //Set esperienza massima nell'HUD
    {
        slider.maxValue = exp;
        slider.value = exp;
    }
    public void SetExp(int exp)                 //Set esperienza corrente nell'HUD
    {
        slider.value = exp;
    }
}

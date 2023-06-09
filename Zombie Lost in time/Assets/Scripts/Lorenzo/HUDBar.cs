using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBar : MonoBehaviour
{
    public Slider slider;

<<<<<<< HEAD
    public void SetMaxHealth(int health)        //Set vita massima nell'HUD
=======
    public void SetMaxHealth(int health)
>>>>>>> Lorenzo
    {
        slider.maxValue = health;
        slider.value = health;
    }
<<<<<<< HEAD
    public void SetHealth(int health)           //Set vita corrente nell'HUD
    {
        slider.value = health;
    }
    public void SetMaxExp(int exp)              //Set esperienza massima nell'HUD
=======
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxExp(int exp)
>>>>>>> Lorenzo
    {
        slider.maxValue = exp;
        slider.value = exp;
    }
<<<<<<< HEAD
    public void SetExp(int exp)                 //Set esperienza corrente nell'HUD
=======
    public void SetExp(int exp)
>>>>>>> Lorenzo
    {
        slider.value = exp;
    }
}

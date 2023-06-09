using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;
        slider.value = exp;
    }
    public void SetExp(int exp)
    {
        slider.value = exp;
    }
}

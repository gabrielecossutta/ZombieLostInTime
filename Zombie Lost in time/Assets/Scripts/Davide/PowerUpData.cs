using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "PowerUp")]
public class PowerUpData : ScriptableObject
{
    public Sprite Icon;
    public PowerUpType powerUpType;
    public int level;
}

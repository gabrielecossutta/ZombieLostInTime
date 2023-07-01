using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    DamageZone,
    RotatingBullet,
    AIMBullet,
    Flamethrower,
    SplitBullet
};
public class PowerUpEnums : MonoBehaviour
{
    public PowerUpType powerUpType;
    public PowerUpData powerUpData;
}

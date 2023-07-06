using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public float bulletsPerSecond;
    public int bulletLifeTime;
    public int magSize;
    public float reloadTimer;
    [Range(1, 10)]public int roundsPerShot;
    public float shotAngleSpread;
    public float randomSpread;
    public int burstSize;
    public float burstTimer;
    public float bulletSpeed;
    public string WeaponName;
    public GameObject bulletPrefab;
    public int fireRateLvlUpgrade;
}

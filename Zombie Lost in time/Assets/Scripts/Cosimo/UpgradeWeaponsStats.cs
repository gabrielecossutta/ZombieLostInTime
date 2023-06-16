using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeaponsStats : Singleton<UpgradeWeaponsStats>
{
    [SerializeField] public float damageUpgrade;
    [SerializeField] public float atkSpeedUpgrade;
    int maxAtkSpeedUpgrade = 6;
    int cont = 0;
    public bool isMaxed;
    public Button atkSpeedButton;
    public void UpgradeDamage()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0)
        {
            Status.Instance.damageBase += damageUpgrade;
            Status.Instance.damageBoss += damageUpgrade;
            UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
        }
    }

    public void UpgradeAtkSpeed()
    {
        if (cont < maxAtkSpeedUpgrade)
        {
            if (UpgradeMenu.Instance.pointsOwned > 0)
            {
                Status.Instance.fireRate += atkSpeedUpgrade;
                UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
                cont++;
            }
        }
        else
        {
            atkSpeedButton.interactable = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeaponsStats : Singleton<UpgradeWeaponsStats>
{
    [SerializeField] public float damageUpgrade;
    [SerializeField] public float fireRateUpgrade;

    int maxFireRateUpgrade = 6;
    int cont = 0;
    public Button fireRateButton;

    public void UpgradeDamage()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0)
        {
            Status.Instance.damageBase += damageUpgrade;
            Status.Instance.damageBoss += damageUpgrade;
            UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
        }
    }

    public void UpgradeFireRate()
    {
        Debug.Log("fuori if");
        if (cont < maxFireRateUpgrade)
        {
            Debug.Log("dentro if");
            if (UpgradeMenu.Instance.pointsOwned > 0)
            {
                Debug.Log("scala punti if");

                GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingBehaviour>().bulletsPerSecond += fireRateUpgrade;
                UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
                cont++;
                Debug.Log(UpgradeMenu.Instance.pointsOwned);
            }
            if (cont == maxFireRateUpgrade)
            {
                Debug.Log("cont == if");

                fireRateButton.interactable = false;
            }
        }
    }

}
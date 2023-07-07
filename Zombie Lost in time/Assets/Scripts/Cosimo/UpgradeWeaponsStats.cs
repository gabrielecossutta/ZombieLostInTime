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
    private GameObject playerRef;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
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
        if (cont < maxFireRateUpgrade)
        {
            if (UpgradeMenu.Instance.pointsOwned > 0)
            {
                playerRef.GetComponent<ShootingBehaviour>().SetUpgradeFireRate(fireRateUpgrade);
                playerRef.GetComponent<ShootingBehaviour>().SetWeaponValues(playerRef.GetComponent<ShootingBehaviour>().GetCurrentWeapon());
                UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
                cont++;
            }
            if (cont == maxFireRateUpgrade)
            {
                fireRateButton.interactable = false;
            }
        }
    }

}
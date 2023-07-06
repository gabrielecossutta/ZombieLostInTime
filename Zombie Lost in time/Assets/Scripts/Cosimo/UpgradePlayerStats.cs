using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayerStats : Singleton<UpgradePlayerStats>
{
    [SerializeField] int healthUpgrade;
    [SerializeField] float speedUpgrade;
    int maxSpeedUpgrade = 20;
    int cont = 0;
    public Button speedButton;

    public void UpgradeHealth()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0)
        {
            Status.Instance.maxHealth += healthUpgrade;
            HUDBar.Instance.slider.maxValue = Status.Instance.maxHealth;
            UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
        }
    }

    public void UpgradeSpeed()
    {
        if (cont < maxSpeedUpgrade)
        {
            if (UpgradeMenu.Instance.pointsOwned > 0)
            {
                Status.Instance.speedUpgradedValue += speedUpgrade;
                UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
                cont++;
            }
            if (cont == maxSpeedUpgrade)
            {
                speedButton.interactable = false;
            }
        }
    }
}

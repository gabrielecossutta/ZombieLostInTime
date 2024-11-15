using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePlayerStats : Singleton<UpgradePlayerStats>
{
    [SerializeField] int healthUpgrade;
    [SerializeField] float speedUpgrade;
    public int maxSpeedUpgrade = 15;
    public int cont = 0;
    public Button speedButton;
    public TMP_Text textMeshPro;

    public void UpgradeHealth()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0)
        {
            Status.Instance.maxHealth += healthUpgrade;
            HUDBar.Instance.slider.maxValue = Status.Instance.maxHealth;
            UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
        }
    }

    public void Check()
    {
        if (cont >= maxSpeedUpgrade)
        {

            textMeshPro.color = Color.black;
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
        }
    }
}

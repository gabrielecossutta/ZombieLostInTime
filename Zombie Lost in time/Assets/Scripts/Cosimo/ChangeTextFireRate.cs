using UnityEngine;
using TMPro;

public class ChangeTextFireRate : Singleton<ChangeTextFireRate>
{
    public TMP_Text textMeshPro;


    public void AddValue()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0 && UpgradeWeaponsStats.Instance.playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade <= UpgradeWeaponsStats.Instance.maxFireRateUpgrade)
        {
            textMeshPro.text = (UpgradeWeaponsStats.Instance.playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade + 1).ToString();
        }
    }

    public void ChangeFireRateWeaponLvl()
    {
        textMeshPro.text = (UpgradeWeaponsStats.Instance.playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade).ToString();
    }
}

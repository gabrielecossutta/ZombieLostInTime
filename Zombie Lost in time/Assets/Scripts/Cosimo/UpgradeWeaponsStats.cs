using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeWeaponsStats : Singleton<UpgradeWeaponsStats>
{
    [SerializeField] public float damageUpgrade;
    [SerializeField] public float fireRateUpgrade;
    public TMP_Text textMeshPro;

    public int maxFireRateUpgrade;
    public int cont = 0;
    public Button fireRateButton;
    public GameObject playerRef;

    private void OnEnable()
    {
        maxFireRateUpgrade = 6;
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    public void Check()
    {
        if (playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade <= maxFireRateUpgrade)
            textMeshPro.color = Color.red;
        else
            textMeshPro.color = Color.black;
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
        if (playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade <= maxFireRateUpgrade)
        {
            if (UpgradeMenu.Instance.pointsOwned > 0)
            {
                playerRef.GetComponent<ShootingBehaviour>().SetUpgradeFireRate(fireRateUpgrade);
                playerRef.GetComponent<ShootingBehaviour>().SetWeaponValues(playerRef.GetComponent<ShootingBehaviour>().GetCurrentWeapon());
                UpgradeMenu.Instance.pointsOwned -= UpgradeMenu.Instance.pointToLvlUp;
                cont++;
            }

            if (playerRef.GetComponent<ShootingBehaviour>().fireRateLvlUpgrade <= maxFireRateUpgrade)
                textMeshPro.color = Color.red;
            else
                textMeshPro.color = Color.black;
        }
    }
}
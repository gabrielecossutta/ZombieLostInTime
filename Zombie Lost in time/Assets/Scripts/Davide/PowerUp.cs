using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public List<PowerUpType> powerUpList = new List<PowerUpType>();
    private Dictionary<PowerUpType, int> powerUpType = new Dictionary<PowerUpType, int>();
    public int MaxLevel = 6;

    private void Start()
    {
        foreach (PowerUpType powerUp in System.Enum.GetValues(typeof(PowerUpType)))
        {
            powerUpList.Add(powerUp);
        }
    }

    public void OnDestroy()
    {
        foreach (var PowerUpList in powerUpList)
        {
            powerUpType.Remove(PowerUpList);
        }
        powerUpType.Clear();
        powerUpList.Clear();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PowerUp"))
        {
            PowerUpData pwrUpDatas = collider.gameObject.GetComponent<PowerUpEnums>().powerUpData;
            PowerUpType powerUp = pwrUpDatas.powerUpType;
            if (!powerUpType.ContainsKey(powerUp) && powerUpList.Contains(powerUp))
            {
                powerUpType.Add(powerUp, 0);
                powerUpType[powerUp]++;
                UpgradePowerUp(powerUp, powerUpType[powerUp]);
                ToolManager.Instance.AddInvP(pwrUpDatas);
            }
            else if (powerUpType.ContainsKey(powerUp))
            {
                if (powerUpType[powerUp] < MaxLevel)
                {
                    powerUpType[powerUp]++;
                    UpgradePowerUp(powerUp, powerUpType[powerUp]);
                    ToolManager.Instance.AddInvP(pwrUpDatas);
                }
                else if (powerUpType[powerUp] == MaxLevel)
                {
                    Debug.Log(powerUp + "Level Max");
                }
            }
            FindObjectOfType<AudioManager>().Play("PickupPowerUp");
            Destroy(collider.gameObject);
        }
    }

    public void AddPowerUp(PowerUpType powerUp)
    {
            switch (powerUp)
            {
                case PowerUpType.DamageZone:
                    this.GetComponent<DamageZone>().DmgZonePicked = true;
                    break;

                case PowerUpType.RotatingBullet:
                    this.GetComponent<RotatingPowerUp>().PowerUpTaken = true;
                    break;

                case PowerUpType.AIMBullet:
                    this.GetComponent<ClosestEnemyPowerUp>().PowerUpTaken = true;
                    break;

                case PowerUpType.SplitBullet:
                    this.GetComponent<RandomBPowerUP>().PowerUpTaken = true;
                    break;
            }
    }

    public void UpgradePowerUp(PowerUpType Type, int currentlevel)
    {
        switch (Type)
        {
            case PowerUpType.DamageZone:

                switch (currentlevel)
                {
                    case 0:
                        break;

                    case 1:
                        AddPowerUp(Type);
                        break;

                    case 2:
                        this.GetComponent<DamageZone>().PlusSize(1);
                        break;

                    case 3:
                        this.GetComponent<DamageZone>().damageDuration += 3;
                        break;

                    case 4:
                        this.GetComponent<DamageZone>().timeSpawn -= 1;
                        break;

                    case 5:
                        this.GetComponent<DamageZone>().PlusSize(1);
                        break;

                    case 6:
                        this.GetComponent<DamageZone>().timeSpawn -= 2;
                        break;
                }
            break;

            case PowerUpType.RotatingBullet:

                switch (currentlevel)
                {
                    case 0:
                        break;

                    case 1:
                        AddPowerUp(Type);
                        break;

                    case 2:
                        ValoreRotaingBullet.Instance.Damage += 5;
                        break;

                    case 3:
                        ValoreRotaingBullet.Instance.Speed += 3;
                        break;

                    case 4:
                        ValoreRotaingBullet.Instance.Range += 2.5f;
                        break;

                    case 5:
                        ValoreRotaingBullet.Instance.Damage += 5;
                        break;

                    case 6:
                        ValoreRotaingBullet.Instance.Speed += 3;
                        break;
                }
            break;

            case PowerUpType.AIMBullet:

                switch (currentlevel)
                {
                    case 0:
                        break;

                    case 1:
                        AddPowerUp(Type);
                        break;

                    case 2:
                        valoreClosestBullet.Instance.Damage += 2;
                        break;

                    case 3:
                        valoreClosestBullet.Instance.speed += 0.025f;
                        break;

                    case 4:
                        this.GetComponent<ClosestEnemyPowerUp>().Time -= 2f;
                        break;

                    case 5:
                        valoreClosestBullet.Instance.Damage += 2;
                        break;

                    case 6:
                        valoreClosestBullet.Instance.speed += 0.025f;
                        break;
                }
            break;

            case PowerUpType.SplitBullet:

                switch (currentlevel)
                {
                    case 0:
                        break;

                    case 1:
                        AddPowerUp(Type);
                        break;

                    case 2:
                        valoreRandomBullet.Instance.Damage += 2;
                        break;

                    case 3:
                        valoreRandomBullet.Instance.UpgradeSpwn3 = true;
                        break;

                    case 4:
                        this.GetComponent<RandomBPowerUP>().Time -= 0.01f;
                        break;

                    case 5:
                        valoreRandomBullet.Instance.Damage += 5;
                        break;

                    case 6:
                        valoreRandomBullet.Instance.UpgradeSpwn5 = true;
                        break;
                }
                break;
        }
    }
}

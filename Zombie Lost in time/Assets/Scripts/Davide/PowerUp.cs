using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType[] powerUpType;
    public int currentlevel = 0;
    public GameObject player;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            UpgradePowerUp(collider.gameObject,currentlevel);
            //Destroy(gameObject);
        }
    }
    public void ApplyPowerUp(GameObject player)
    {
        for (int i = 0; i < powerUpType.Length; i++)
        {
            switch (powerUpType[i])
            {
                case PowerUpType.DamageZone:
                    player.GetComponent<DamageZone>().DmgZonePicked = true;
                    currentlevel = 1;
                    break;

                case PowerUpType.SimpleBullet:
                    player.GetComponent<PlayerShoot>().SimpleBulletEnable = true;
                    currentlevel = 1;
                    break;

                case PowerUpType.RotatingBullet:
                    //player.GetComponent<DamageZone>().DmgZonePicked = true;
                    currentlevel = 1;
                    break;

                case PowerUpType.AIMBullet:
                    //player.GetComponent<DamageZone>().DmgZonePicked = true;
                    currentlevel = 1;
                    break;
            }
        }
    }
    public void UpgradePowerUp(GameObject player, int currentlevel)
    {
        // Esegui le azioni specifiche per il tipo di power-up
        for (int i = 0; i < powerUpType.Length; i++)
        {
            switch (powerUpType[i])
            {
                case PowerUpType.DamageZone:

                    switch (currentlevel)
                    {
                        case 0:
                            ApplyPowerUp(player);
                            break;

                        case 1:
                            break;

                        case 2:
                            player.GetComponent<DamageZone>().PlusSize(2);
                            break;

                        case 3:
                            player.GetComponent<DamageZone>().damageDuration += 3;
                            break;

                        case 4:
                            player.GetComponent<DamageZone>().timeSpawn -= 1;
                            break;

                        case 5:
                            player.GetComponent<DamageZone>().PlusSize(4);
                            break;

                        case 6:
                            player.GetComponent<DamageZone>().timeSpawn -= 2;
                            break;
                    }
                break;

                case PowerUpType.SimpleBullet:

                    switch (currentlevel)
                    {
                        case 0:
                            ApplyPowerUp(player);
                            break;

                        case 2:
                            //Aumento danno Bullet
                            break;

                        case 3:
                            player.GetComponent<PlayerShoot>().TripleFireSkill = true;
                            break;

                        case 4:
                            player.GetComponent<PlayerShoot>().FireRateSkill = true;
                            break;

                        case 5:
                            //Aumento danno Bullet
                            break;

                        case 6:
                            player.GetComponent<PlayerShoot>().QuintupleFireSkill = true;
                            break;
                    }
                break;

                case PowerUpType.RotatingBullet:

                    switch (currentlevel)
                    {
                        case 0:
                            ApplyPowerUp(player);
                            break;

                        case 2:
                            //Aumento danno Bullet
                            break;

                        case 3:
                            //Upgrade Power Up
                            break;

                        case 4:
                            // Aumento velocità Bullet
                            break;

                        case 5:
                            //Aumento danno Bullet
                            break;

                        case 6:
                            //Upgrade Power Up
                            break;
                    }
                break;

                case PowerUpType.AIMBullet:

                    switch (currentlevel)
                    {
                        case 0:
                            ApplyPowerUp(player);
                            break;

                        case 2:
                            //Aumento danno Bullet
                            break;

                        case 3:
                            //Upgrade Power Up
                            break;

                        case 4:
                            //Aumento numero Bullet
                            break;

                        case 5:
                            //Aumento danno Bullet
                            break;

                        case 6:
                            //Upgrade Power Up
                            break;
                    }
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            ApplyPowerUp(collider.gameObject);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void ApplyPowerUp(GameObject player)
    {
        switch (powerUpType)
        {
            case PowerUpType.DamageZone:
                player.GetComponent<DamageZone>().DmgZonePicked = true;
                //powerUpType.currentlevel
                break;
            case PowerUpType.SimpleBullet:
                player.GetComponent<PlayerShoot>().SimpleBulletEnable = true;
                break;
            case PowerUpType.RotatingBullet:
                //player.GetComponent<DamageZone>().DmgZonePicked = true;
                break;
            case PowerUpType.AIMBullet:
                //player.GetComponent<DamageZone>().DmgZonePicked = true;
                break;
        }
    }
}

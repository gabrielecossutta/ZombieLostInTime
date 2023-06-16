 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PowerUpType {DamageZone, FireRate, TripleFire, QuintupleFire, RotatingPowerUp, AttackClosestEnemy};
    public PowerUpType powerUpType;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            ApplyPowerUp(collider.gameObject);

            Destroy(gameObject);
        }
    }
    private void ApplyPowerUp(GameObject player)
    {
        // Esegui le azioni specifiche per il tipo di power-up
        switch (powerUpType)
        {
            case PowerUpType.DamageZone:

                player.GetComponent<DamageZone>().DmgZonePicked = true;
                break;

            case PowerUpType.FireRate:

                player.GetComponent<PlayerShoot>().FireRateSkill = true;
                break;

            case PowerUpType.TripleFire:

                player.GetComponent<PlayerShoot>().TripleFireSkill = true;
                break;

            case PowerUpType.QuintupleFire:

                player.GetComponent<PlayerShoot>().QuintupleFireSkill = true;
                break;
            
            case PowerUpType.RotatingPowerUp:

                player.GetComponent<PowerUpRotante>().PowerUpTaken = true;
                break;
            
            case PowerUpType.AttackClosestEnemy:

                player.GetComponent<PowerUpNemicoVicino>().PowerUpTaken = true;
                break;

        }
    }
}

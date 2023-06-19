using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTest : MonoBehaviour
{
    public int levelUp = 1;
    public PowerUp powerUp;
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            levelUp ++;
            powerUp.UpgradePowerUp(collider.gameObject, levelUp);
            //Destroy(gameObject);
        }
    }
}

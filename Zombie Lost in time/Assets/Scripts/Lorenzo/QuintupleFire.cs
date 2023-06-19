using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuintupleFire : MonoBehaviour
{
    public PlayerShoot playerShoot;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerShoot.QuintupleFireSkill = true;
            Destroy(gameObject);
        }
    }

}

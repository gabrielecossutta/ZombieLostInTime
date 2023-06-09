using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleFire : MonoBehaviour
{
    public PlayerShoot playerShoot;


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerShoot.TripleFireSkill = true;  
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageZoneScript : MonoBehaviour
{
    public float damageAmount = 10f; 
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBoss"))
        {
            
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount * Time.deltaTime);
        }
    }
}

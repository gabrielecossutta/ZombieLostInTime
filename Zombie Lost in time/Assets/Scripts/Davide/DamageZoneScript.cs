using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageZoneScript : MonoBehaviour
{
    public float damageAmount = 10f; 
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBig"))
        {
            Debug.Log("Damaged");
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount * Time.deltaTime);
        }
    }
    public void PlusSize(float size)
    {
        Vector3 newScale = transform.localScale + new Vector3(size, 0f, size);

        transform.localScale = newScale;
    }
}

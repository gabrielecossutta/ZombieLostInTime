using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = MaxHealth;
    }


    public void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            EnemyKilledCounter.Instance.EnemyKilled();
            //Debug.Log("Enemy dead");
            //currentHealth = MaxHealth;
            Destroy(gameObject);
            gameObject.GetComponent<Enemy>().SpawnExp();

        }
    }
}

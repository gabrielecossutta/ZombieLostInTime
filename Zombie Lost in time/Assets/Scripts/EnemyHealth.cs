using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float currentHealth;
    public float FlameDamage=25; 
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
    public void OnParticleCollision(GameObject other) // fanno lancia fiamme
    {
        
        TakeDamage(FlameDamage);
    }
}

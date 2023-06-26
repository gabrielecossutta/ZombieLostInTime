using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float currentHealth;
    public float DamageFlameTrowher = 10;

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
            Destroy(gameObject);
            gameObject.GetComponent<Enemy>().SpawnExp();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(DamageFlameTrowher);
    }
}

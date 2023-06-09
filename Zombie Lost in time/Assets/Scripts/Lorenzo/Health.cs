using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
            Debug.Log("The player is dead");
            currentHealth = MaxHealth;
        }
    }
}

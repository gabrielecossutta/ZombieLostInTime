using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxHealth;
    public int damageBoss;
    public int damageBase;
    public int currentExp;
    public int currentHealth;
    public int expToLvlUp;
    public int healUp;
    public int currentLevel;
    public HUDBar healthBar;
    public HUDBar expBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        expBar.SetMaxExp(expToLvlUp);
        expBar.SetExp(currentExp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            int totalHealth = currentHealth + healUp;
            if (totalHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = totalHealth;
            }
            healthBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("ExpBoss"))
        {
            ExpGained(5);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("ExpBase"))
        {
            ExpGained(2);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("DamageBoss"))
        {
            currentHealth -= damageBoss;
            healthBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("DamageBase"))
        {
            currentHealth -= damageBase;
            healthBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void ExpGained(int exp)
    {
        currentExp += exp;
        Debug.Log("Esperienza totale: " + currentExp);

        if (currentExp >= expToLvlUp)
        {
            LevelUp();
        }
        expBar.SetExp(currentExp);
    }
    public void LevelUp()
    {
        currentLevel++;
        int excessExp = currentExp - expToLvlUp;
        currentExp = excessExp;
        expToLvlUp += 3;
        expBar.SetMaxExp(expToLvlUp);
        Debug.Log("Livello " + currentLevel);
        Debug.Log("Esperienza in eccesso:" + currentExp);

    }
}

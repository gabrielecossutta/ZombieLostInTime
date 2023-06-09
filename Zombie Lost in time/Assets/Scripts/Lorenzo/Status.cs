using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> Lorenzo

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
<<<<<<< HEAD

    void Start()
    {
        //Set della barra vita ed esperienza
=======
    // Start is called before the first frame update
    void Start()
    {
>>>>>>> Lorenzo
        healthBar.SetMaxHealth(maxHealth);
        expBar.SetMaxExp(expToLvlUp);
        expBar.SetExp(currentExp);
    }
<<<<<<< HEAD
=======

    // Update is called once per frame
>>>>>>> Lorenzo
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        // In base a quale tag è associato l'oggetto scatta il suo trigger e vengono disattivati

        if (other.CompareTag("Health"))
        {
            int totalHealth = currentHealth + healUp;
            if (totalHealth > maxHealth)                // verifica della sua vita massima e che non vada oltre
=======
        if (other.CompareTag("Health"))
        {
            int totalHealth = currentHealth + healUp;
            if (totalHealth > maxHealth)
>>>>>>> Lorenzo
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = totalHealth;
            }
<<<<<<< HEAD
            healthBar.SetHealth(currentHealth);         //set vita aggiornato
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("ExpBoss"))           //Esperienza Boss
=======
            healthBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("ExpBoss"))
>>>>>>> Lorenzo
        {
            ExpGained(5);
            other.gameObject.SetActive(false);
        }
<<<<<<< HEAD
        else if (other.CompareTag("ExpBase"))           //Esperienza Base
=======
        else if (other.CompareTag("ExpBase"))
>>>>>>> Lorenzo
        {
            ExpGained(2);
            other.gameObject.SetActive(false);
        }
<<<<<<< HEAD
        else if (other.CompareTag("DamageBoss"))        //Danno Boss
        {
            currentHealth -= damageBoss;
            healthBar.SetHealth(currentHealth);         //set vita aggiornato
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("DamageBase"))        //Danno Base
        {
            currentHealth -= damageBase;
            healthBar.SetHealth(currentHealth);         //set vita aggiornato
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        if (currentHealth <= 0)                         //Check verifica se la vita scende a 0 o sotto
=======
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
>>>>>>> Lorenzo
        {
            gameObject.SetActive(false);
        }
    }

<<<<<<< HEAD
    public void ExpGained(int exp)                      //Funzione per l'esperienza acquisita
=======
    public void ExpGained(int exp)
>>>>>>> Lorenzo
    {
        currentExp += exp;
        Debug.Log("Esperienza totale: " + currentExp);

        if (currentExp >= expToLvlUp)
        {
            LevelUp();
        }
        expBar.SetExp(currentExp);
    }
<<<<<<< HEAD
    public void LevelUp()                               //Funzione per il nuovo livello raggiunto
=======
    public void LevelUp()
>>>>>>> Lorenzo
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : Singleton<Status>
{
    public int maxHealth;
    public int currentExp;
    public int currentHealth;
    public int expToLvlUp;
    public int healUp;
    public int currentLevel;
    private int enemyKilledCounter;
    public HUDBar healthBar;
    public HUDBar expBar;
    public GameObject HUD;
    public TMP_Text enemyKilledText;
    public TMP_Text currentHeathText;
    public float damageBase;
    public float damageBoss;
    public float fireRate;
    [HideInInspector] public float speedUpgradedValue;
    [HideInInspector] public float damageUpgradedValue;
    public Animator animator;

    void Start()
    {
        //Set della barra vita ed esperienza
        fireRate = 0.5f;
        healthBar.SetMaxHealth(maxHealth);
        expBar.SetMaxExp(expToLvlUp);
        expBar.SetExp(currentExp);
        currentHealth = maxHealth;
        currentHeathText.text = currentHealth.ToString();
    }

    void Update()
    {
        if (currentHealth <= 0)                         //Check verifica se la vita scende a 0 o sotto
        {
            gameObject.SetActive(false);
            HUD.SetActive(false);
            TimerController.Instance.PlayerDeath();
            //Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // In base a quale tag è associato l'oggetto scatta il suo trigger e vengono disattivati

        if (other.CompareTag("Health"))
        {
            int totalHealth = currentHealth + healUp;
            if (totalHealth > maxHealth)                // verifica della sua vita massima e che non vada oltre
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth = totalHealth;
            }
            healthBar.SetHealth(currentHealth);         //set vita aggiornato
            Debug.Log(currentHealth);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("ExpBoss"))           //Esperienza Boss
        {
            ExpGained(5);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ExpBase"))           //Esperienza Base
        {
            ExpGained(2);
            Destroy(other.gameObject);
        }
        //else if (other.CompareTag("DamageBoss"))        //Danno Boss
        //{
        //    currentHealth -= damageBoss;
        //    healthBar.SetHealth(currentHealth);         //set vita aggiornato
        //    Debug.Log(currentHealth);
        //    other.gameObject.SetActive(false);
        //}
        //else if (other.CompareTag("DamageBase"))        //Danno Base
        //{
        //    currentHealth -= damageBase;
        //    healthBar.SetHealth(currentHealth);         //set vita aggiornato
        //    Debug.Log(currentHealth);
        //    other.gameObject.SetActive(false);
        //}

    }

    public void ExpGained(int exp)                      //Funzione per l'esperienza acquisita
    {
        currentExp += exp;
        Debug.Log("Esperienza totale: " + currentExp);

        if (currentExp >= expToLvlUp)
        {
            LevelUp();
        }
        expBar.SetExp(currentExp);
    }

    public void LevelUp()                               //Funzione per il nuovo livello raggiunto
    {
        UpgradeMenu.Instance.OpenUpgradeMenu(1);
        currentLevel++;
        int excessExp = currentExp - expToLvlUp;
        currentExp = excessExp;
        expToLvlUp += 3;
        expBar.SetMaxExp(expToLvlUp);
        Debug.Log("Livello " + currentLevel);
        Debug.Log("Esperienza in eccesso:" + currentExp);

    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            enemyKilledCounter = EnemyKilledCounter.Instance.enemyKilled;
            enemyKilledText.text = "Enemy Killed: " + enemyKilledCounter.ToString();
            Debug.Log("The player is dead Status");
            //currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);

        }
    }
}

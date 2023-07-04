using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Status : Singleton<Status>
{
    [SerializeField] private int baseExpGain;
    public int maxHealth;
    public int currentExp;
    public int currentHealth;
    public int expToLvlUp;
    public int healUp;
    public int currentLevel;
    private int enemyKilledCounter;
    [SerializeField] private HUDBar healthBar;
    [SerializeField] private HUDBar expBar;
    [SerializeField] private GameObject HUD;
    [SerializeField] private TMP_Text enemyKilledText;
    [SerializeField] private TMP_Text currentHeathText;
    public float damageBase;
    public float damageBoss;
    public float damageBig;
    public float fireRate;
    [HideInInspector] public float speedUpgradedValue;
    public Animator animator;
    public GameObject loadingPanel;
    public int c;

    void Start()
    {
        //Set della barra vita ed esperienza
        fireRate = 0.5f;
        healthBar.SetMaxHealth(maxHealth);
        expBar.SetMaxExp(expToLvlUp);
        expBar.SetExp(currentExp);
        currentHealth = maxHealth;
        currentHeathText.text = currentHealth.ToString();
        c = 0;
    }

    void Update()
    {
        if (currentHealth <= 0)                         //Check verifica se la vita scende a 0 o sotto
        {
            gameObject.SetActive(false);
            HUD.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // In base a quale tag � associato l'oggetto scatta il suo trigger e vengono disattivati

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
            ExpGained(baseExpGain);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ExpBase"))           //Esperienza Base
        {
            ExpGained(baseExpGain);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Portal"))
        {


            TimerController.Instance.changingEra = false;

            MapLoader.Instance.portal.SetActive(false);
            

            StartCoroutine(ActivateLoadingPanelAfterDelay(2f));
            c++;
        }
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

    private IEnumerator ActivateLoadingPanelAfterDelay(float delay)
    {
        
        loadingPanel.SetActive(true); // Disattiva il loadingPanel
        if (c == 0)
        {
            MapLoader.Instance.ChangeScene();
            Debug.Log("Nell' IF "+ MapLoader.Instance.Era);
            
        }
        if (c == 1)
        {
            MapLoader.Instance.ChangeScene2();
            Debug.Log("Nell' IF " + MapLoader.Instance.Era);
        }
        if (c == 2)
        {
            MapLoader.Instance.ChangeScene3();
            Debug.Log("Nell' IF " + MapLoader.Instance.Era);
        }


        yield return new WaitForSeconds(delay); // Attendi il numero di secondi specificato


        loadingPanel.SetActive(false); // Attiva nuovamente il loadingPanel
    }
}

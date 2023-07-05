using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nottepertutti : Singleton<Nottepertutti>
{
    public GameObject enemyContainer;
    public List<Enemy> allchildren = new List<Enemy>();
    public List<Spawner> allSpawner = new List<Spawner>();
    public GameObject[] enemies; // Lista dei nemici
    private Transform player;
    public GameObject[] boss;

    // Start is called before the first frame update
    void Start()
    {
        //Trova il gameobject chiamato EnemyContainer
        enemyContainer = GameObject.Find("EnemyContainer");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        // distrugge gli enemy se troppo lontani dal player per non averne troppi
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boss = GameObject.FindGameObjectsWithTag("EnemyBoss");
        foreach (GameObject enemy in enemies)
        {
            Vector3 direction = enemy.transform.position - player.position;
            float currentDistance = direction.magnitude;
            if (currentDistance>70)
            {
                Destroy(enemy);
            }
            if (enemy.transform.position.y > 1)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z);
            }

        }
        foreach (GameObject boss in boss)
        {
            if (boss.transform.position.y > 1)
            {
                boss.transform.position = new Vector3(boss.transform.position.x, 0, boss.transform.position.z);
            }
        }
    }

    public void SetNotteToAllEnemy()
    {
        //grazia al fatto che tutti i nemici sono stati spawnati dentro un gameobject, li posso mette tutti dentro una lista prendendoli come figli
        Enemy[] childTransforms = enemyContainer.GetComponentsInChildren<Enemy>(true);
        foreach (Enemy childTransform in childTransforms)
        {

            allchildren.Add(childTransform); // li aggiungo alla lista

        }
        foreach(Enemy child in allchildren)
        {
            child.setNotteTrue(); //gli dico che è notte e che devono scappare
            
        }
        foreach(Spawner spawner in allSpawner)
        {
            spawner.gameObject.SetActive(false); //disattivo gli spawner
        }
    }

    public void SetGiornoToAllEnemy()
    {
        foreach(Enemy child in allchildren)
        {
            child.setNotteFalse(); //gli dico che è giorno e che devono attacarmi
        }
        foreach(Spawner spawner in allSpawner)
        {
            spawner.gameObject.SetActive(true); // riattivo gli spawner
        }
        allchildren.Clear();
    }

    public void ClearAll()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject boss in boss)
        {
            Destroy(boss);
        }

    }
}

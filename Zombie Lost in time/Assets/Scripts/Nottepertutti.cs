using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nottepertutti : MonoBehaviour
{
    public GameObject enemyContainer;
    public List<Enemy> allchildren = new List<Enemy>();
    public List<Spawner> allSpawner = new List<Spawner>();
        public GameObject[] players; // Lista dei nemici
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //Trova il gameobject chiamato EnemyContainer
        enemyContainer = GameObject.Find("EnemyContainer");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {// cancella i cubi se troppo lontani dal player per non averne troppi
    players = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in players)
        {
            Vector3 direction = enemy.transform.position - player.position;
            float currentDistance = direction.magnitude;
            if (currentDistance>50)
            {
                Destroy(enemy);
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
            child.setNotteTrue(); //gli dico che � notte e che devono scappare
            
        }
        foreach(Spawner spawner in allSpawner)
        {
            spawner.gameObject.SetActive(false); //disattivo gli spawner
            //spawner.SetActive(false);
        }
    }
    public void SetGiornoToAllEnemy()
    {
        foreach(Enemy child in allchildren)
        {
            child.setNotteFalse(); //gli dico che � giorno e che devono attacarmi
        }
        foreach(Spawner spawner in allSpawner)
        {
            spawner.gameObject.SetActive(true); // riattivo gli spawner
        }
        allchildren.Clear();
    }
}
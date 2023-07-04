using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NemicoPiùVicino : Singleton<NemicoPiùVicino>
{
    private GameObject enemyContainer; //Riferimento Contenitore Nemici
    public GameObject closestEnemy; // Riferimento nemico più vicino
    private GameObject[] EnemyContainer; // tutti i nemici piccoli
    private GameObject[] BigEnemyContainer; // tutti i nemici Grandi
    public GameObject[] MergedContainer; // tutti i nemici in 1 solo contenitore
    private void Start()
    {
        GameObject enemyContainer = GameObject.Find("EnemyContainer");
    }
    public void Update()
    {
        float closestDistance = 1000000f; //distanza da nemico a player
        EnemyContainer = GameObject.FindGameObjectsWithTag("Enemy");
        BigEnemyContainer = GameObject.FindGameObjectsWithTag("EnemyBoss");
        MergedContainer = EnemyContainer.Concat(BigEnemyContainer).ToArray(); //unisce tutti i nemici in 1 contenitore
        foreach (GameObject enemy in MergedContainer) //per ogni nemico controlla qual è il più vicino
        {
            float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, enemy.transform.position); // calcola la distanza tra player e nemico
            if (distance < closestDistance) // controlla e salva la distanza e salva il nemico più veloce
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
    }
}
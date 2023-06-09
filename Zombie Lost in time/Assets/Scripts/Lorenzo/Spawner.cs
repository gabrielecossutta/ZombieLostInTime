using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] private float nightTimer = 10f;

    private Coroutine currentCoroutine;

    public bool isNight;

    
    private void Start()
    {
        currentCoroutine = StartCoroutine(Spawning());
        //StartCoroutine(StopSpawning(nightTimer));
    }
    public void Update()
    {
        
    }
    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }

        
    }

   //public IEnumerator StopSpawning(float nightTime)
   // {
   //     yield return new WaitForSeconds(nightTimer);
   //     Debug.Log("Stopping spawning" );

        

   //     // Trova tutti gli oggetti istanziati nel gioco
   //     GameObject[] instantiatedObjects = GameObject.FindGameObjectsWithTag("Enemy");

   //     // Loop attraverso tutti gli oggetti e cambia la variabile
   //     foreach (GameObject obj in instantiatedObjects)
   //     {
   //         obj.GetComponent<Enemy>().Notte = true;
   //     }

   //     StopCoroutine(currentCoroutine);
   // }
}

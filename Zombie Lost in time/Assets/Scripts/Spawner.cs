using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    //[SerializeField] private float nightTimer = 10f;
    public Transform EnemyContainer;

    private Coroutine currentCoroutine;

    public bool isNight;

    private void Start()
    {
        //StartCoroutine(StopSpawning(nightTimer));
        StartCoroutine(Spawning());
    }

    public void Update()
    {
        if (transform.position.z >= -160)
        {
            transform.position = new Vector3(transform.position.x, 0, -160);
        }
        else if (transform.position.z <= -390)
        {
            transform.position = new Vector3(transform.position.x, 0, -390);
        }
        else if (transform.position.x <= -110)
        {
            transform.position = new Vector3(-117, 0, transform.position.z);
        }
        else if (transform.position.x >= 117)
        {
            transform.position = new Vector3(110, 0, transform.position.z);
        }
    }
    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity, EnemyContainer);
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

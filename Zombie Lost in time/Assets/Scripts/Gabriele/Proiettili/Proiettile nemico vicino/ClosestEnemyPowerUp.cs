using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyPowerUp : MonoBehaviour
{
    public GameObject bullet;  //riferimento proiettile
    public bool PowerUpTaken = false;
    private bool Executed = false;
    public float Time = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpTaken)
        {
            if (!Executed)// booleana per spawnare solo 1 proiettile
            {
                Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                Executed = true;
                StartCoroutine(SpawnBullet(Time)); //cooroutine che spawna un proiettile ogni "Time"
            }
        }
    }
    private IEnumerator SpawnBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity); //Spawna un proiettile alla posizione del player
        StartCoroutine(SpawnBullet(Time));
    }

}

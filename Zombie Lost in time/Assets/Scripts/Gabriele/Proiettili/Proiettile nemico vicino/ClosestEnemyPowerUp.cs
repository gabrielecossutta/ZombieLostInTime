using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyPowerUp : MonoBehaviour
{
    public GameObject bullet;  //riferimento proiettile
    public bool PowerUpTaken = false;
    private bool Executed = false;
    public float Time = 2.5f;
    void Update()
    {
        if (PowerUpTaken)
        {
            if (!Executed)// booleana per spawnare solo 1 proiettile
            {
                if (NemicoPi�Vicino.Instance.closestEnemy != null)
                {
                    Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity); //Spawna un proiettile alla posizione del player
                }
                Executed = true;
                StartCoroutine(SpawnBullet(Time)); //cooroutine che spawna un proiettile ogni "Time"
            }
        }
    }
    private IEnumerator SpawnBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (NemicoPi�Vicino.Instance.closestEnemy != null)
        {
        Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity); //Spawna un proiettile alla posizione del player
        }
            StartCoroutine(SpawnBullet(Time));
        
    }
}

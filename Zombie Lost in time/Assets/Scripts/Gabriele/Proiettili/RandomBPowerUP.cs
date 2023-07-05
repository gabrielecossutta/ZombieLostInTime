using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBPowerUP : MonoBehaviour
{
    public GameObject bullet;  //riferimento proiettile
    public bool PowerUpTaken = false;
    private bool Executed = false;
    public float Time = 1.5f;

    void FixedUpdate()
    {
        if (PowerUpTaken)
        {
            if (!Executed)// booleana per spawnare solo 1 proiettile
            {
                Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position,Quaternion.Euler(0, Random.Range(0, 360), 0));
                Executed = true;
                StartCoroutine(SpawnBullet(Time)); //cooroutine che spawna un proiettile ogni "Time"
            }
        }
    }

    private IEnumerator SpawnBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)); //Spawna un proiettile alla posizione del player
        StartCoroutine(SpawnBullet(Time));
    }
}

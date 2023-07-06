using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyPowerUp : MonoBehaviour
{
    public GameObject bullet;  //riferimento proiettile
    public bool PowerUpTaken = false;
    private bool Executed = false;
    public float Time;

    private void Start()
    {
        Time = 3.5f;
    }

    void Update()
    {
        if (PowerUpTaken)
        {
            if (!Executed)// booleana per spawnare solo 1 proiettile
            {
                if (NemicoPiùVicino.Instance.closestEnemy != null)
                {
                    Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity); //Spawna un proiettile alla posizione del player
                }
                Executed = true;
                FindObjectOfType<AudioManager>().Play("AIMShot");
                StartCoroutine(SpawnBullet(Time)); //cooroutine che spawna un proiettile ogni "Time"
            }
        }
    }
    private IEnumerator SpawnBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (NemicoPiùVicino.Instance.closestEnemy != null)
        {
            Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity); //Spawna un proiettile alla posizione del player
        }
        FindObjectOfType<AudioManager>().Play("AIMShot");
        StartCoroutine(SpawnBullet(Time));

    }
}

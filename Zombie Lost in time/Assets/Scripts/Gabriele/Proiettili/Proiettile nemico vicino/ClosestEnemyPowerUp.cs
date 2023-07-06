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
                    Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                    Vector3 enemyPosition = NemicoPiùVicino.Instance.closestEnemy.transform.position;
                    Vector3 direction = enemyPosition - playerPosition;
                    Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90,0,0);
                    Instantiate(bullet, playerPosition + (Vector3.up * 2), rotation);

                }
                Executed = true;
                StartCoroutine(SpawnBullet(Time)); //cooroutine che spawna un proiettile ogni "Time"
            }
        }
    }
    private IEnumerator SpawnBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (NemicoPiùVicino.Instance.closestEnemy != null)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 enemyPosition = NemicoPiùVicino.Instance.closestEnemy.transform.position;
            Vector3 direction = enemyPosition - playerPosition;
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);

            Instantiate(bullet, playerPosition + (Vector3.up * 2), rotation);
        }
        StartCoroutine(SpawnBullet(Time));

    }
}

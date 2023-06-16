using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public GameObject damageZonePrefab;
    public float timeSpawn = 4f;
    public float damageDuration = 5f;
    public bool DmgZonePicked;
    public float timer = 0f;
    void Start()
    {
        DmgZonePicked = false;
    }

// Update is called once per frame
    void Update()
    {
        if (DmgZonePicked)
        {
            if (timer >= timeSpawn)
            {
                CreateDamageZone();
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
    public void CreateDamageZone()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 spawnOffset = new Vector3(Random.Range(-15f, 15f), 1f, Random.Range(-15f, 15f));
        Vector3 spawnPoint = playerPos + spawnOffset;

        GameObject damageZone = Instantiate(damageZonePrefab, spawnPoint, Quaternion.identity);
        Destroy(damageZone, damageDuration);
    }
}

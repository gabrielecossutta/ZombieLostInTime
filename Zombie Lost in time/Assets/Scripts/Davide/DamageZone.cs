using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public GameObject damageZonePrefab;
    public float timeSpawn = 4f;
    public float damageDuration = 5f;
    public bool DmgZonePicked;
    public float timer = 0f;
    private GameObject damageZone;
    private Vector3 originalScale;
    void Start()
    {
        DmgZonePicked = false;
        StoreOriginalSize();
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
        Vector3 spawnOffset = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
        Vector3 spawnPoint = playerPos + spawnOffset;

        damageZone = Instantiate(damageZonePrefab, spawnPoint, Quaternion.identity);
        PlusSize(0);
        FindObjectOfType<AudioManager>().Play("DamageZone");
        Destroy(damageZone, damageDuration);
    }
    public void PlusSize(float size)
    {
        Vector3 newScale = damageZonePrefab.transform.localScale;
        newScale.x += size;
        newScale.z += size;
        damageZonePrefab.transform.localScale = newScale;
    }
    public void ResetSize()
    {
        damageZonePrefab.transform.localScale = originalScale;
    }
    public void StoreOriginalSize()
    {
        originalScale = damageZonePrefab.transform.localScale;
    }
    public void OnDestroy()
    {
        ResetSize();
    }
}

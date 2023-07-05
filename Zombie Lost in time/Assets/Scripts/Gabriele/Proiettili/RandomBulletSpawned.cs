using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletSpawned : MonoBehaviour
{
    public float speed = 5f;
    public float Damage = 5f;
    public Collider enemyHit; // collider del nemico che li ha fatti spawnare
    void Start()
    {

    }
    public RandomBulletSpawned(Collider collider)
    {
        enemyHit = collider; // passo il collider del nemico che ha colpito il primo proiettile
    }
    void Update()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemyHit != other) // controlla che il collider non sia lo stesso del nemico che li ha fatti spawnare
        {
            if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
            {
                other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
                Destroy(gameObject);
            }
        }
    }
}

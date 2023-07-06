using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClosestEnemy : Singleton<BulletClosestEnemy>
{
    public float Damage = 5; //danno proiettile
    public Transform ClosestEnemy; //Posizione Nemico Più Vicino
    public float speed;
    private bool Executed = false;
    public Vector3 movement;

    private void Start()
    {
        speed = 0.05f;
    }

    void Update()
    {
        if (!Executed) // booleana per eseguire il codice solo una volta
        {
            ClosestEnemy = NemicoPiùVicino.Instance.closestEnemy.transform;
            Executed = true;
            Vector3 direction = new Vector3 (ClosestEnemy.position.x, ClosestEnemy.position.y+0.5f, ClosestEnemy.position.z) - transform.position;
            direction.Normalize();
            movement = direction * speed;
        }
        transform.position += movement;
        Destroy(gameObject,7.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBoss"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
            Destroy(gameObject);
        }
    }
}

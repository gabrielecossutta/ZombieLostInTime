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
            Vector3 direction = ClosestEnemy.position - transform.position;
            direction.Normalize();
            movement = direction * speed;
        }
        transform.position += movement;
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

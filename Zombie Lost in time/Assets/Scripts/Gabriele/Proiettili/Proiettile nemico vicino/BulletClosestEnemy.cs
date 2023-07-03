using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClosestEnemy : Singleton<BulletClosestEnemy>
{
    public float Damage = 5; //danno proiettile
    //public GameObject Bullet; //riferimento al proiettile
    public Transform ClosestEnemy; //Posizione Nemico Più Vicino
    public float speed;
    private bool Executed = false;
    public Vector3 movement;
    public Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        speed = 0.1f;
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
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
            Destroy(gameObject);
        }
    }
}

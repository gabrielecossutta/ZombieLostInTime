using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClosestEnemy : Singleton<BulletClosestEnemy>
{
    public float Damage = 5; //danno proiettile
    //public GameObject Bullet; //riferimento al proiettile
    public Transform ClosestEnemy; //Posizione Nemico Più Vicino
    public float speed = 0.05f;
    private bool Executed = false;
    void Update()
    {
        if (!Executed) // booleana per eseguire il codice solo una volta
        {
            ClosestEnemy = NemicoPiùVicino.Instance.closestEnemy.transform;
            Executed = true;
        }
        //movimento Proiettile verso nemico
        transform.position = Vector3.MoveTowards(transform.position, ClosestEnemy.position, speed);
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

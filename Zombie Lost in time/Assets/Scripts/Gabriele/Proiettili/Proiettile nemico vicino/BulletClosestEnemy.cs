using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClosestEnemy : MonoBehaviour
{
    public float Damage = 5; //danno proiettile
    public GameObject Bullet; //riferimento al proiettile
    public Transform ClosestEnemy; //Posizione Nemico Più Vicino
    private bool Executed = false;
    void Start()
    {

    }
    void Update()
    {

        if (!Executed) // booleana per eseguire il codice solo una volta
        {
            ClosestEnemy = NemicoPiùVicino.Instance.closestEnemy.transform;
            Executed = true;
        }
        //movimento Proiettile verso nemico
        transform.position = Vector3.MoveTowards(transform.position, ClosestEnemy.position, 0.05f);
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

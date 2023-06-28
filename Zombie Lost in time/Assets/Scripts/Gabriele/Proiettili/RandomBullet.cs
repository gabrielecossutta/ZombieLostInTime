using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullet : Singleton<RandomBullet>
{
    public float speed = 5f;
    public float Damage = 5f;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Bullet;
    public bool UpgradeSpwn3 = false;
    public bool UpgradeSpwn5 = false;

    void Update()
    {
        // Calcolare lo spostamento in base alla direzione forward e alla velocit�
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement);
        //colpisce

        //si divide in 2 
    }
    private void OnTriggerEnter(Collider other)
    {
        // SALVARE IL NEMICO COLPITO PER CONTROLLARLO NELL'ALTRO PROIETTILE
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno

            if (UpgradeSpwn5)
            {
                Instantiate(Bullet, Spawner4.transform.position, Spawner4.transform.rotation);
                Instantiate(Bullet, Spawner5.transform.position, Spawner5.transform.rotation);
            }
            if (UpgradeSpwn3)
            {
                Instantiate(Bullet, Spawner3.transform.position, Spawner3.transform.rotation);

            }
            Instantiate(Bullet, Spawner1.transform.position, Spawner1.transform.rotation);
            Instantiate(Bullet, Spawner2.transform.position, Spawner2.transform.rotation);
            Destroy(gameObject);
        }
    }
}
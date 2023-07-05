using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullet : Singleton<RandomBullet>
{
    public float speed = 10f;
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
        // Calcolare lo spostamento in base alla direzione forward e alla velocità
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement);
        //colpisce

        //si divide in 2 
    }
    private void OnTriggerEnter(Collider other)
    {
        // SALVARE IL NEMICO COLPITO PER CONTROLLARLO NELL'ALTRO PROIETTILE
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBoss"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
            
            if (UpgradeSpwn5)
            {
                RandomBulletSpawned Bullet4 = Instantiate(Bullet, Spawner4.transform.position, Spawner4.transform.rotation).GetComponent<RandomBulletSpawned>(); // spawn il proiettile con le coordinate dello spawner 1
                Bullet4.enemyHit = other; // passo il collider del nemico, cosi da non far distruggere i proiettili creati contro lo stesso nemico
                RandomBulletSpawned Bullet5 = Instantiate(Bullet, Spawner5.transform.position, Spawner5.transform.rotation).GetComponent<RandomBulletSpawned>();// spawn il proiettile con le coordinate dello spawner 2
                Bullet5.enemyHit = other;// passo il collider del nemico, cosi da non far distruggere i proiettili creati contro lo stesso nemico
            }
            if (UpgradeSpwn3)
            {
                RandomBulletSpawned Bullet3 = Instantiate(Bullet, Spawner3.transform.position, Spawner3.transform.rotation).GetComponent<RandomBulletSpawned>(); // spawn il proiettile con le coordinate dello spawner 1
                Bullet3.enemyHit = other; // passo il collider del nemico, cosi da non far distruggere i proiettili creati contro lo stesso nemico

            }
            RandomBulletSpawned Bullet1 = Instantiate(Bullet, Spawner1.transform.position, Spawner1.transform.rotation).GetComponent<RandomBulletSpawned>(); // spawn il proiettile con le coordinate dello spawner 1
            Bullet1.enemyHit = other; // passo il collider del nemico, cosi da non far distruggere i proiettili creati contro lo stesso nemico
            RandomBulletSpawned Bullet2 = Instantiate(Bullet, Spawner2.transform.position, Spawner2.transform.rotation).GetComponent<RandomBulletSpawned>();// spawn il proiettile con le coordinate dello spawner 2
            Bullet2.enemyHit = other;// passo il collider del nemico, cosi da non far distruggere i proiettili creati contro lo stesso nemico
            Destroy(gameObject); // distruggo il proiettile
        }
    }
}

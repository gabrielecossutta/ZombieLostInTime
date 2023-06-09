using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed; //velocita del proiettile
    [SerializeField] private Transform gunOffset; //punto da dove esce il proiettile
    [SerializeField] private Transform gunOffset2; //offset utilizzato in caso di sparo triplo
    [SerializeField] private Transform gunOffset3; //offset utilizzato in caso di sparo triplo
    [SerializeField] private Transform gunOffset4; //offset utilizzato in caso di sparo quintuplo
    [SerializeField] private Transform gunOffset5; //offset utilizzato in caso di sparo quintuplo
    [SerializeField] private float fireRate; //piu e' basso e piu spara veloce

    public bool TripleFireSkill;
    public bool FireRateSkill;
    public bool QuintupleFireSkill;

    private float lastFireTime; //ultima volta che e' stato sparato un colpo

    private void Start()
    {
        TripleFireSkill = false;
        FireRateSkill = false;
        QuintupleFireSkill = false;
}


    void Update()
    {
        float timeSinceLastFire = Time.time - lastFireTime;

        if (timeSinceLastFire >= fireRate)
        {
            FireBullet();

            if (TripleFireSkill) //se raccolgo il power up spara triplo
            {             
                TripleFire();  
            }

            if(FireRateSkill)
            {
                FireRate();
                FireRateSkill = false;
            }

            if(TripleFireSkill && QuintupleFireSkill)
            {
                QuintupleFire();
            }

            lastFireTime = Time.time;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.velocity = bulletSpeed * gunOffset.forward.normalized; //prende la velocity dal forward del punto di spawn del proiettile
    }

    private void TripleFire() //Aggiunge i 2 spari laterali allo sparo base
    {
        GameObject bullet2 = Instantiate(bulletPrefab, gunOffset2.position, transform.rotation);
        Rigidbody rigidbody2 = bullet2.GetComponent<Rigidbody>();
        rigidbody2.velocity = bulletSpeed * gunOffset2.forward;

        GameObject bullet3 = Instantiate(bulletPrefab, gunOffset3.position, transform.rotation);
        Rigidbody rigidbody3 = bullet3.GetComponent<Rigidbody>();
        rigidbody3.velocity = bulletSpeed * gunOffset3.forward;
    }

    private void FireRate() //Diminuisce il fire rate dello sparo
    {
        fireRate = fireRate * 0.5f;
    }

    private void QuintupleFire()
    {
        GameObject bullet4 = Instantiate(bulletPrefab, gunOffset4.position, transform.rotation);
        Rigidbody rigidbody4 = bullet4.GetComponent<Rigidbody>();
        rigidbody4.velocity = bulletSpeed * gunOffset4.forward;

        GameObject bullet5 = Instantiate(bulletPrefab, gunOffset5.position, transform.rotation);
        Rigidbody rigidbody5 = bullet5.GetComponent<Rigidbody>();
        rigidbody5.velocity = bulletSpeed * gunOffset5.forward;
    }


}

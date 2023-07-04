using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotatingPowerUp : Singleton<BulletRotatingPowerUp>
{
    public float Range = 2f;
    public float Speed = 3f;
    public float Damage = 5f;
    public float rotationSpeed;
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Mathf.Sin(Time.time*Speed)*Range, 1.5f, Mathf.Cos(Time.time*Speed)*Range);
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage); //Applica Danno
        }
    }
}

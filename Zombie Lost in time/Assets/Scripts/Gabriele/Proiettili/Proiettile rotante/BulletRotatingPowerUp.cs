using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotatingPowerUp : Singleton<BulletRotatingPowerUp>
{
    public float Range;
    public float Speed;
    public float Damage;
    public float rotationSpeed;
    private void Start()
    {
     
    }
    void Update()
    {
        Range = ValoreRotaingBullet.Instance.Range;
        Speed = ValoreRotaingBullet.Instance.Speed;
        Damage = ValoreRotaingBullet.Instance.Damage;
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Mathf.Sin(Time.time*Speed)*Range, 1.5f, Mathf.Cos(Time.time*Speed)*Range);
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            FindObjectOfType<AudioManager>().Play("ShieldHit");
            other.GetComponent<EnemyHealth>().TakeDamage(Damage); //Applica Danno
        }
    }
}

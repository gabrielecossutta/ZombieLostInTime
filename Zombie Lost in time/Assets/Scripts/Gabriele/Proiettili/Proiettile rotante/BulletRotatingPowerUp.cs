using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotatingPowerUp : MonoBehaviour
{
    public float Range = 2f;
    public float Speed = 3f;
    public float Damage = 5f;

    void Start()
    {
        
    }
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Mathf.Sin(Time.time*Speed)*Range, 0, Mathf.Cos(Time.time*Speed)*Range);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
        }
    }
}

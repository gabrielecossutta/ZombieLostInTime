using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] public float speed = 100f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody rb;
    public float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.tag == "Enemy")
       {
            collision.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBase);
            
            Destroy(gameObject);
       }
       else if (collision.collider.tag == "EnemyBig")
       {
            collision.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBig);

            Destroy(gameObject);
       }
        else if (collision.collider.tag == "EnemyBoss")
        {
            collision.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);

            Destroy(gameObject);
        }
    }

    
}

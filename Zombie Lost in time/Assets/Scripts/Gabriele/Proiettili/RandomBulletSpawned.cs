using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletSpawned : MonoBehaviour
{
    public float speed = 5f;
    public float Damage = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement);
        
    }

    private void OnTriggerEnter(Collider other)
    {//DEVO TENERE CONTO DELL'ULTIMO NEMICO COLPITO E NON DEVE ESSERE LUI
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
            Destroy(gameObject);
        }
    }
}

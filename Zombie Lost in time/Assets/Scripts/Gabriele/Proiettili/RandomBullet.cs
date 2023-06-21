using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullet : MonoBehaviour
{
    public float speed = 5f;
    public float Damage = 5f;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);//Applica Danno
            Instantiate(Bullet, Spawner1.transform.position, Spawner1.transform.rotation);
            Instantiate(Bullet, Spawner2.transform.position, Spawner2.transform.rotation);
            Destroy(gameObject);
        }
    }
}

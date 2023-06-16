using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProiettileClosestEnemy : MonoBehaviour
{
    public float damage = 5;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, NemicoPiùVicino.Instance.closestEnemy.transform.position, 0.05f);
        
    }
    private void OnDestroy()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBig"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Destroy(gameObject);
            
        }
    }
}

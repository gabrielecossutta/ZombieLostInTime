using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotatingPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Mathf.Sin(Time.time*2)*3, 0, Mathf.Cos(Time.time*2)*3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1000);
        }
        else if (other.tag == "EnemyBig")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1000);
        }
    }
}

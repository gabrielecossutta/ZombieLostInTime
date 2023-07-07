using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("FlameThrower");
            Status.Instance.FlameThrower.Play();
            Destroy(gameObject);
        }
    }

}

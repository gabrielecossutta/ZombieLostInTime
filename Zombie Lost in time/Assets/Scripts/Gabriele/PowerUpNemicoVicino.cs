using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpNemicoVicino : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PowerUpTaken = false;
    public GameObject bullet;  
    private bool Executed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpTaken)
        {
            if (!Executed)
            {
                Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                Executed = true;
            StartCoroutine(ExecuteAfterDelay(2.5f));
            }
        }
    }
    private IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bullet, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        StartCoroutine(ExecuteAfterDelay(3f));
    }

}

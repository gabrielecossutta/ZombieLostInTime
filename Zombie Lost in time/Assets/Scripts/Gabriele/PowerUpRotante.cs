using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotante : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PowerUpTaken = false;
    public GameObject RotatingPrefab;  
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
            Instantiate(RotatingPrefab);
            Executed = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPowerUp : MonoBehaviour
{
    public GameObject Bullet;  //Riferimento Proiettile
    public bool PowerUpTaken = false;
    private bool Executed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpTaken)
        {
            if (!Executed) // booleana per eseguire il codice solo una volta
            {
            Instantiate(Bullet);
            Executed = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowColor : MonoBehaviour
{
    public float Speed = 0.5f; // Velocità cambio del colore
    public float hue; //tonalità in base HSV

    public void Start()
    {
        hue = 0f;
    }

    public void Update()
    {

        hue += Time.deltaTime* Speed;
       
        if (hue > 1f)// il valore hue deve rimanere tra lo 0 se no diventa nero
        {
            hue -= 1f;
        }
        // Imposta il colore sul Renderer
        GetComponent<Renderer>().material.color = Color.HSVToRGB(hue, 1f, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0, z); //vettore direzione a cui vogliamo andare

        if (direction != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(direction);
            transform.rotation = toRotate; //rotazione del player in base a dove stiamo andando
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime); //movimento player alla pressione dei tasti

        }
    }
}

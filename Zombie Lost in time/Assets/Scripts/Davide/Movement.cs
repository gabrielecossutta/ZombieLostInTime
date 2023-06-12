using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private Rigidbody Rb;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //if (direction != Vector3.zero)
        //{
        //    Quaternion toRotate = Quaternion.LookRotation(direction);
        //    transform.rotation = toRotate; //rotazione del player in base a dove stiamo andando
        //}
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime); //movimento player alla pressione dei tasti
        //    direction = new Vector3(x, 0, z); //vettore direzione a cui vogliamo andare

        //}
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (direction != Vector3.zero)
        {
            Quaternion ToRotate = Quaternion.LookRotation(direction);
            transform.rotation = ToRotate; //rotazione del player in base a dove stiamo andando
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(x, 0, z); //vettore direzione a cui vogliamo andare
            if (direction.magnitude > 1f)
            {
                direction.Normalize();
            }

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
        }
        else
        {
            Rb.velocity = Vector3.zero;
        }
    }
}

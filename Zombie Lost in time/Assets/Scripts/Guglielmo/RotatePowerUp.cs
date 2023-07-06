using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUp : MonoBehaviour
{
    public int rotationSpeed;
    public bool right;
    public bool up;
    public bool back;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            rotationSpeed = Random.Range(50, 101);
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        }
        if (up)
        {
            rotationSpeed = Random.Range(50, 101);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (back)
        {
            rotationSpeed = Random.Range(50, 101);
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
    }
}

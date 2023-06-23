using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawner : MonoBehaviour
{
    public int rotationSpeed;
    void Update()
    {
        rotationSpeed = Random.Range(50, 101);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

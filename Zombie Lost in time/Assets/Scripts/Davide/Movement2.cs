using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement2 : MonoBehaviour
{
    public float speed, rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float yRot = Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;


        transform.Translate(new Vector3(x, 0, z), Space.Self);
        transform.Rotate(new Vector3(0, yRot, 0), Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyDrop : MonoBehaviour
{

    private float lifeTime = 1f;
    // Start is called before the first frame update



    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
}

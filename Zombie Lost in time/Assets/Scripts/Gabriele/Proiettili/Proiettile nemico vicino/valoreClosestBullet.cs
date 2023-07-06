using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valoreClosestBullet : Singleton<valoreClosestBullet>
{
    // Start is called before the first frame update
    public float Damage; //danno proiettile
    public float speed;
    void Start()
    {
        Damage = 5;
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

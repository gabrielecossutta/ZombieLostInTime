using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValoreRotaingBullet : Singleton<ValoreRotaingBullet>
{
    public float Range;
    public float Speed;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        Range = 2.5f;
        Speed = 3f;
        Damage = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

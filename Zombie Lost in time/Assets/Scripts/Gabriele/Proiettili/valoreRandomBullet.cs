using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valoreRandomBullet : Singleton<valoreRandomBullet>
{
    // Start is called before the first frame update
    public bool UpgradeSpwn3;
    public bool UpgradeSpwn5;
    public float speed;
    public float Damage;
    void Start()
    {
        speed=10f;
        Damage=5f;
        UpgradeSpwn3 = false;
        UpgradeSpwn5 = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

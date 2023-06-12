using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    public float Speed; // velocita dei nemici 
    private Transform player; // transform del player

    void Start()
    {
        Speed = 3;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player); // i nemici guardano il player
        transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime); // i nemici vanno verso il player
    }
}

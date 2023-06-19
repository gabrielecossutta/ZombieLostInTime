using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeFromPlayer : MonoBehaviour
{
    public float Speed; // velocita di allontanamento
    public float distance;// distanza da cui iniziano ad allontanarsi
    private Transform player; // transform del player
    public float velocitaSguardo; // quanto veloce si girano
    void Start()
    {
        distance = 15f;
        Speed = 3;
        velocitaSguardo = 10f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector3 direction = transform.position - player.position; // direzione di dove devono scappare (in contrario di dove arriva il player)
        float currentDistance = direction.magnitude; //calcola quanto è distante dal player
        if (currentDistance < distance) // controlla se il player è nel range e se lo è inizia a scappare
        {
            Vector3 targetPosition = transform.position + direction.normalized; 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime); 
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocitaSguardo * Time.deltaTime);
        }
    }
}

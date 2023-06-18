using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float SightRange;
    [SerializeField] private float DetectionRange;

    [SerializeField] private int Damage;
    [SerializeField] private Transform Enemycontainer;
    [SerializeField] private Animator animator;

    [SerializeField] private float Speed; // velocita di allontanamento
    [SerializeField] private Transform player; // transform del player
    [SerializeField] private float velocitaSguardo; // quanto veloce si girano

    [SerializeField] private GameObject[] drop;

    [SerializeField] private float attackRange = 5f;

    void Start()
    {
        Speed = 2.5f;
        velocitaSguardo = 7.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetFloat("Speed_f", 1);
        animator.SetInteger("WeaponType_int", 0);
    }

    void Update()
    {
        // Calcola la distanza tra il nemico e il giocatore
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Controlla se il giocatore è nel range di attacco
        if (distanceToPlayer <= attackRange)
        {
            animator.SetInteger("WeaponType_int", 12);
            animator.SetFloat("Speed_f", 0f);
        }
        else
        {
            animator.SetInteger("WeaponType_int", 0);
            animator.SetFloat("Speed_f", 1);

            if (TimerController.Instance.IsNight)
            {
                // VANNO VIA DAL PLAYER
                Vector3 direction = transform.position - player.position; // direzione di dove devono scappare (in contrario di dove arriva il player)
                float currentDistance = direction.magnitude; //calcola quanto � distante dal player
                Vector3 targetPosition = transform.position + direction.normalized;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocitaSguardo * Time.deltaTime);

            }
            else
            {   //VANNO VERSO IL PLAYER
                transform.LookAt(player); // i nemici guardano il player
                transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime); // i nemici vanno verso il player
            }
        }
    }

    private void OnAnimationComplete()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        // Applica danni al giocatore
        //Status.Instance.TakeDamage(Damage);
    }

    public void SpawnExp()
    {
        int rand = Random.Range(0, drop.Length);
        Instantiate(drop[rand], transform.position + new Vector3(0,1,0), Quaternion.identity);
    }

    public void setNotteTrue()
    {
        TimerController.Instance.IsNight = true;
    }

    public void setNotteFalse()
    {
        TimerController.Instance.IsNight = false;
    }
}

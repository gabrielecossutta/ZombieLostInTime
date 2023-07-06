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

    [SerializeField] public float Speed = 3f; // velocita dell'enemy
    [SerializeField] private Transform player; // transform del player
    [SerializeField] private float velocitaSguardo; // quanto veloce si girano
    public Rigidbody enemyRB;
    [SerializeField] private GameObject[] drop;

    [SerializeField] private float attackRange = 3f;
    public GameObject bossDrop;
    


    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        velocitaSguardo = 7.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetFloat("Speed_f", 1);
        animator.SetInteger("WeaponType_int", 0);
        
    }

    void FixedUpdate()
    {
        // Calcola la distanza tra il nemico e il giocatore
        // Calcola la distanza tra il nemico e il giocatore
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Controlla se il giocatore è nel range di attacco
        if (distanceToPlayer <= attackRange)
        {
            transform.LookAt(player); // i nemici guardano il player
            animator.SetInteger("WeaponType_int", 12);
            animator.SetFloat("Speed_f", 0f);
        }
        else
        {
            animator.SetInteger("WeaponType_int", 0);
            animator.SetFloat("Speed_f", 1);

            if (TimerController.Instance.IsNight)
            {
                
                    // TORNANO A RINCORRERTI
                    Vector3 direction = player.position - transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocitaSguardo * Time.deltaTime);
                    direction.Normalize();
                    Vector3 movement = direction * Speed;
                    enemyRB.MovePosition(enemyRB.position + movement * Time.deltaTime);
                
            }
            else
            {
                Vector3 direction = player.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, velocitaSguardo * Time.deltaTime);
                direction.Normalize();
                Vector3 movement = direction * Speed;
                enemyRB.MovePosition(enemyRB.position + movement * Time.deltaTime);
                
            }
        }
    }

    private void OnAnimationComplete()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            // Applica danni al giocatore
            Status.Instance.TakeDamage(Damage);
        }
    }

    public void SpawnExp()
    {
        if (TimerController.Instance.IsNight && !CompareTag("EnemyBoss"))
        {
            Instantiate(drop[7], transform.position + Vector3.up, Quaternion.Euler(-13,-8,15));
        }
        else if (!TimerController.Instance.IsNight && !CompareTag("EnemyBoss"))
        {
            int rand = Random.Range(0, drop.Length);
            Instantiate(drop[rand], transform.position + Vector3.up, Quaternion.identity);
        }
        else if (CompareTag("EnemyBoss"))
        {
            Instantiate(bossDrop, transform.position + Vector3.up, Quaternion.Euler(-13, -8, 15));
        }
    }

    public void setNotteTrue()
    {
        TimerController.Instance.IsNight = true;
    }

    public void setNotteFalse()
    {
        TimerController.Instance.IsNight = false;
    }

    public bool InBound()
    {
        if (transform.position.x > -106f && transform.position.x < 110f &&
            transform.position.z > -383f && transform.position.z < -166f)
        {
            return true; // Gli enemy sono all'interno dei limiti della mappa
        }

        return false; // Gli enemy sono fuori dai limiti della mappa
    }
}



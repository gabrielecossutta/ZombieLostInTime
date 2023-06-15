using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxSpeed;
    private float speed;

    public float SightRange;
    public float DetectionRange;

    [SerializeField]private Rigidbody Rb;

    public int Damage;
    public float KOTime;

    private bool CanAttack = true;

    public Transform Enemycontainer;
    [SerializeField] private Animator animator;
    //vita enemy

    public float Speed; // velocita di allontanamento
    public float distance;// distanza da cui iniziano ad allontanarsi
    private Transform player; // transform del player
    public float velocitaSguardo; // quanto veloce si girano

    public GameObject[] drop;

    void Start()
    {
        distance = 10;
        Speed = 2.5f;
        velocitaSguardo = 7.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = MaxSpeed;
        animator.SetFloat("Speed_f", 1);
        animator.SetInteger("WeaponType_int", 0);
    }


    void Update()
    {
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
        {//VANNO VERSO IL PLAYER
            transform.LookAt(player); // i nemici guardano il player
            transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime); // i nemici vanno verso il player
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Status>().TakeDamage(Damage);
            StartCoroutine(AttackDelay(KOTime));
        }
    }

    IEnumerator AttackDelay(float Delay)
    {
        speed = 0.2f;
        CanAttack = false;
        yield return new WaitForSeconds(Delay);
        speed = MaxSpeed;
        CanAttack = true;
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

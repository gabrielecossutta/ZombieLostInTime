using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxSpeed;
    private float speed;

    private Collider[] hitCollider;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody Rb;
    public GameObject Target;
    public GameObject[] drop;

    private bool seePlayer;

    public int Damage;
    public float KOTime;

    public bool CanAttack = true;
    public bool Notte ;

    
    //vita enemy


    void Start()
    {
        speed = MaxSpeed;
        Notte = false;
}

    
    void Update()
    {
        //cerca player nel range 
        
        if (!seePlayer)
        {
            hitCollider = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitCollider)
            {
                if (HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else if (Notte)
        {
            var Heading = Target.transform.position - transform.position;
            var Distance = Heading.magnitude;
            var Direction = Heading / Distance;

            // muove verso il player
            Vector3 Move = new Vector3(-Direction.x * speed, 0, -Direction.z * speed);
            Rb.velocity = Move;
            transform.forward = -Move;
        }
        else
        {
            if (Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    //calcolo della direzione 
                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;

                    // muove verso il player
                    Vector3 Move = new Vector3(Direction.x * speed, 0, Direction.z * speed);
                    Rb.velocity = Move;
                    transform.forward = Move;
                }
            }
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
        int rand = Random.Range(0,drop.Length);
        Instantiate(drop[rand], transform.position, Quaternion.identity);
        
    }
   
}

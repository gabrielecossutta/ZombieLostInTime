using UnityEngine;

public class BulletLogic : Singleton<BulletLogic>
{
    public float bulletSpeed = 10f;
    public float bulletRange = 100f;
    public LayerMask enemyLayer;
    [SerializeField] private ParticleSystem hitFx;
    [SerializeField] private float lifeTime;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Applica una forza per far muovere il proiettile in avanti
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private void Update()
    {
        // Esegui il Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, bulletRange, enemyLayer))
        {
            // Controlla se il Raycast ha colpito un nemico
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    // Il proiettile ha colpito un nemico
                    enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBase);
                    Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else if (hit.collider.CompareTag("EnemyBig"))
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);
                    Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));

                }
                //Destroy(gameObject);
            }
        }
        Debug.Log("Raycast Fallito");

        //Destroy(gameObject, lifeTime);
    }
}


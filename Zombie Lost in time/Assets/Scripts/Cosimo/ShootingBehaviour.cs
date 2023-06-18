using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Queue<GameObject> BulletPool;
    private float timer;
    private float timer_elapsed;

    public float bulletsPerSecond;
    [SerializeField] private int bulletLifeTime;
    [SerializeField] private int poolSize;
    [SerializeField] private int magSize;
    [SerializeField] private float reloadTimer;
    [Range(1, 10)][SerializeField] private int roundsPerShot;
    [SerializeField] private float shotAngleSpread;
    [SerializeField] private float randomSpread;
    [SerializeField] private int burstSize;
    [SerializeField] private float burstTimer;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private float raycastRange;
    [SerializeField] private ParticleSystem hitFx;

    private float shotAngleDelta;
    private float halfSpread;
    private float reloadTimer_elapsed;
    private float burstTimer_elapsed;
    private float bulletsPerSecondAtStart;
    private int currentBurst;
    private int currentMag;
    private bool shootRoutine;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Status>().animator;

        currentMag = magSize;
        currentBurst = burstSize;
        bulletsPerSecondAtStart = bulletsPerSecond;

        timer_elapsed = 0;
        timer = 1f / bulletsPerSecond;
        reloadTimer_elapsed = 0f;
        burstTimer_elapsed = burstTimer;

        shotAngleDelta = shotAngleSpread / (roundsPerShot > 1 ? roundsPerShot - 1 : roundsPerShot);
        halfSpread = shotAngleSpread * 0.5f;
        BulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gO = Instantiate(BulletPrefab);
            gO.SetActive(false);
            BulletPool.Enqueue(gO);
        }
    }

    void Update()
    {
        //if (currentMag > 0)
        //{

        //}
        //else
        //{
        //    if (reloadTimer_elapsed >= reloadTimer)
        //    {
        //        reloadTimer_elapsed = 0f;
        //        currentMag = magSize;
        //    }
        //    else
        //    {
        //        reloadTimer_elapsed += Time.deltaTime;
        //    }
        //}

        if (timer_elapsed >= timer)
        {
            timer_elapsed = 0f;
            shootRoutine = true;
            currentMag--;

            if (bulletsPerSecondAtStart < bulletsPerSecond)
            {
                timer = 1f / bulletsPerSecond;
                bulletsPerSecondAtStart = bulletsPerSecond;
            }
        }
        timer_elapsed += Time.deltaTime;

        if (shootRoutine)
        {
            ShootingRoutine();
            animator.SetBool("Shoot_b", true);
            if (bulletsPerSecond > 2)
            {
                animator.SetBool("FullAuto_b", true);
            }
            else
            {
                animator.SetBool("FullAuto_b", false);
            }
        }

        // Controlla le collisioni dei proiettili attivi
        CheckBulletCollisions();
    }

    void CheckBulletCollisions()
    {
        GameObject[] bullets = BulletPool.ToArray(); // Crea una copia temporanea dei proiettili

        foreach (GameObject bullet in bullets)
        {
            if (bullet.activeInHierarchy)
            {
                BulletCollision.Instance.OnTriggerEnter(bullet.GetComponent<SphereCollider>());
                RaycastHit hit;
                if (Physics.Raycast(bullet.transform.position, bullet.transform.forward, out hit, raycastRange, collisionLayers))
                {
                    //Controlla se il Raycast ha colpito un nemico
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            //enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBase);
                            Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
                        }
                        else if (hit.collider.CompareTag("EnemyBig"))
                        {
                            //enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);
                            Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
                        }
                    }
                    // Disabilita il proiettile e lo rimette nella pool
                    bullet.SetActive(false);
                    BulletPool.Enqueue(bullet);
                }
            }
        }
    }

    void ShootingRoutine()
    {
        if (burstTimer_elapsed >= burstTimer)
        {
            burstTimer_elapsed = 0f;
            currentBurst--;
            if (roundsPerShot == 1)
            {
                GameObject bullet = BulletPool.Dequeue();
                bullet.transform.position = GameObject.FindGameObjectWithTag("Barrel").transform.position;
                bullet.transform.rotation = transform.rotation * Quaternion.AngleAxis(Random.Range(-randomSpread, randomSpread), transform.up);
                bullet.SetActive(true);
                BulletPool.Enqueue(bullet);

                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

                // Assegna la velocità al proiettile
                bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;

                // Avvia la coroutine per reinserire il proiettile nella coda dopo un certo periodo di tempo
                StartCoroutine(ResetBulletAfterDelay(bullet, bulletLifeTime));
            }
            else
            {
                for (int i = 0; i < roundsPerShot; i++)
                {
                    GameObject bullet = BulletPool.Dequeue();
                    bullet.transform.position = GameObject.FindGameObjectWithTag("Barrel").transform.position;
                    bullet.transform.rotation = transform.rotation * Quaternion.AngleAxis((-halfSpread + i * shotAngleDelta + Random.Range(-randomSpread, randomSpread)), transform.up);
                    bullet.SetActive(true);
                    BulletPool.Enqueue(bullet);

                    // Aggiungi il componente Rigidbody al proiettile
                    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

                    // Assegna la velocità al proiettile
                    bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;

                    // Avvia la coroutine per distruggere il proiettile dopo un certo periodo di tempo
                    StartCoroutine(ResetBulletAfterDelay(bullet, bulletLifeTime));
                }
            }
        }

        burstTimer_elapsed += Time.deltaTime;
        if (currentBurst <= 0)
        {
            shootRoutine = false;
            currentBurst = burstSize;
        }
    }

    IEnumerator ResetBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Disabilita il proiettile e lo rimette nella pool
        bullet.SetActive(false);
        BulletPool.Enqueue(bullet);
    }
}



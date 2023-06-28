using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public GameObject BulletPrefab;
    public int currentWeaponIndex = 0;
    public float bulletsPerSecond;

    [SerializeField] private int bulletLifeTime;
    [SerializeField] private int poolSize;
    [SerializeField] private int magSize;
    [SerializeField] private float reloadTimer;
    [Range(1, 10)][SerializeField] private int roundsPerShot;
    [SerializeField] private float shotAngleSpread;
    [SerializeField] private float randomSpread;
    [SerializeField] private int burstSize;
    [SerializeField] private float burstTimer;//tempo tra il primo colpo e il seguente all'interno di una raffica
    [SerializeField] private float bulletSpeed;
    [SerializeField] private LayerMask collisionLayers;
    [SerializeField] private float raycastRange;
    [SerializeField] private ParticleSystem hitFx;

    private Queue<GameObject> BulletPool;
    private float timer;
    private float timer_elapsed;
    private float shotAngleDelta;
    private float halfSpread;
    private float reloadTimer_elapsed;
    private float burstTimer_elapsed;
    private float bulletsPerSecondAtStart;
    private int currentBurst;
    private int currentMag;
    private bool shootRoutine;

    private Animator animator;
    private bool weaponSwitched = false;

    void Start()
    {
        if (weapons.Count > 0)
        {
            SetWeaponValues(weapons[0]);
        }

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
        SelectWeaponByInput();

        if (weaponSwitched)
        {
            timer_elapsed = -0.2f;
            weaponSwitched = false;
        }

        if (currentMag > 0)
        {
            if (timer_elapsed >= timer)
            {
                timer_elapsed = 0f;
                shootRoutine = true;
                animator.SetBool("Shoot_b", true);
                if (bulletsPerSecond > 2)
                {
                    animator.SetBool("FullAuto_b", true);
                }
                else
                {
                    animator.SetBool("FullAuto_b", false);
                }
                currentMag--;
   
                if (bulletsPerSecondAtStart < bulletsPerSecond) // Upgrade del fire rate tramite UpgradeMenu
                {
                    timer = 1f / bulletsPerSecond;
                    bulletsPerSecondAtStart = bulletsPerSecond;
                }
            }
            timer_elapsed += Time.deltaTime;
 
        }
        else
        {
            if (reloadTimer_elapsed >= reloadTimer)
            {
                reloadTimer_elapsed = 0f;
                currentMag = magSize;
            }
            else
            {
                animator.SetBool("Shoot_b", false);
                reloadTimer_elapsed += Time.deltaTime;
            }
        }

        if (shootRoutine)
        {
            ShootingRoutine();
        }

        // Controlla le collisioni dei proiettili attivi
        CheckBulletCollisions();
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);

        // Imposta l'arma appena aggiunta se è la prima arma ottenuta
        if (weapons.Count == 1)
        {
            SetWeaponValues(weapon);
        }
    }

    void SetWeaponValues(Weapon weapon)
    {
        bulletsPerSecond = weapon.bulletsPerSecond;
        bulletLifeTime = weapon.bulletLifeTime;
        magSize = weapon.magSize;
        reloadTimer = weapon.reloadTimer;
        roundsPerShot = weapon.roundsPerShot;
        shotAngleSpread = weapon.shotAngleSpread;
        randomSpread = weapon.randomSpread;
        burstSize = weapon.burstSize;
        burstTimer = weapon.burstTimer;
        bulletSpeed = weapon.bulletSpeed;

        currentMag = magSize;
        currentBurst = burstSize;
        bulletsPerSecondAtStart = bulletsPerSecond;
        timer_elapsed = 0;
        timer = 1f / bulletsPerSecond;
        reloadTimer_elapsed = 0f;
        burstTimer_elapsed = burstTimer;
        shotAngleDelta = shotAngleSpread / (roundsPerShot > 1 ? roundsPerShot - 1 : roundsPerShot);
        halfSpread = shotAngleSpread * 0.5f;
    }

    void SwitchToNextWeapon()
    {
        if (weapons.Count <= 1)
        {
            return; // Non ci sono altre armi da cambiare
        }

        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }

        SetWeaponValues(weapons[currentWeaponIndex]);
    }

    void SelectWeaponByInput()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButton("YButton")) && weapons.Count >= 1 )
        {
            weaponSwitched = true;
            SetWeaponValues(weapons[0]);
            currentWeaponIndex = 0;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButton("BButton")) && weapons.Count >= 2 && WeaponCollisionDetector.Instance.akOwned)
        {
            weaponSwitched = true;
            SetWeaponValues(weapons[1]);
            currentWeaponIndex = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetButton("AButton")) && weapons.Count >= 3 && WeaponCollisionDetector.Instance.shotgunDBOwned)
        {
            weaponSwitched = true;
            SetWeaponValues(weapons[2]);
            currentWeaponIndex = 2;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetButton("XButton")) && weapons.Count >= 4 && WeaponCollisionDetector.Instance.MinigunOwned)
        {
            weaponSwitched = true;
            SetWeaponValues(weapons[3]);
            currentWeaponIndex = 3;
        }
    }

    public string GetCurrentWeaponName()
    {
        if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Count)
        {
            Weapon currentWeapon = weapons[currentWeaponIndex];
            return currentWeapon.WeaponName;
        }

        return string.Empty;
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
                            enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBase);
                            Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
                        }
                        else if (hit.collider.CompareTag("EnemyBig"))
                        {
                            enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);
                            Instantiate(hitFx, hit.point, Quaternion.LookRotation(hit.normal));
                        }
                        else if (hit.collider.CompareTag("EnemyBoss"))
                        {
                            enemy.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);
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



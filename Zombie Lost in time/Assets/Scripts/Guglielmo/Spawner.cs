using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float bossSpawnRate = 10f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private List<GameObject> bossPrefab;
    [SerializeField] public bool canSpawn = true;
    [SerializeField] private bool bossCanSpawn = true;
    public Transform EnemyContainer;
    public bool isNight;
    public int howManyBoss;
    public int bossNumber;
    private Coroutine spawningCoroutine;
    private Coroutine bossSpawningCoroutine;
    public int EraStart;
    public int EraEnd;
    [SerializeField] private float obstacleCheckRadius = 1f;

    private void Start()
    {
        howManyBoss = 0;
        bossNumber = 2;
        EraStart = 0;
        EraEnd = 2;
        StartSpawning();
    }

    private void OnEnable()
    {
        StartSpawning();
        StartBossSpawning();
    }

    private void OnDisable()
    {
        StopSpawning();
        StopBossSpawning();
    }

    public void StartSpawning()
    {
        if (spawningCoroutine == null)
        {
            spawningCoroutine = StartCoroutine(Spawning());
        }
    }

    public void StartBossSpawning()
    {
        if (bossSpawningCoroutine == null)
        {
            bossSpawningCoroutine = StartCoroutine(BossSpawning());
        }
    }

    public void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }
    }

    public void StopBossSpawning()
    {
        if (bossSpawningCoroutine != null)
        {
            StopCoroutine(bossSpawningCoroutine);
            bossSpawningCoroutine = null;
        }
    }

    public void SetCanSpawn(bool spawn)
    {
        canSpawn = spawn;

        if (canSpawn && spawningCoroutine == null)
        {
            StartSpawning();
        }
    }

    public void SetBossCanSpawn(bool spawn)
    {
        bossCanSpawn = spawn;

        if (bossCanSpawn && bossSpawningCoroutine == null)
        {
            StartBossSpawning();
        }
    }

    public void FixedUpdate()
    {
        if (!canSpawn && spawningCoroutine != null)
        {
            StopSpawning();
            spawningCoroutine = null;
        }
        else if (canSpawn && spawningCoroutine == null)
        {
            StartSpawning();
        }

        if (!bossCanSpawn && bossSpawningCoroutine != null)
        {
            StopBossSpawning();
            bossSpawningCoroutine = null;
        }
        else if (bossCanSpawn && bossSpawningCoroutine == null)
        {
            StartBossSpawning();
        }

        if (howManyBoss == bossNumber)
        {
            SetBossCanSpawn(false);
        }
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            if (canSpawn  && !HasObstacleInContact() && InBound())
            {
                int rand = Random.Range(EraStart, EraEnd);
                GameObject enemyToSpawn = enemyPrefabs[rand];
                Instantiate(enemyToSpawn, transform.position, Quaternion.identity, EnemyContainer);
                yield return wait;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private IEnumerator BossSpawning()
    {
        WaitForSeconds waitBoss = new WaitForSeconds(bossSpawnRate);

        while (true)
        {
                yield return waitBoss;
            if (bossCanSpawn && !HasObstacleInContact() && InBound())
            {
                Instantiate(bossPrefab[howManyBoss], transform.position, Quaternion.identity, EnemyContainer);
                bossPrefab.RemoveAt(howManyBoss);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void SetSpawnRate(float value)
    {
        spawnRate = value;
    }

    public bool InBound()
    {
        if ((transform.position.x < 110f && transform.position.x > -106f) && (transform.position.z < -166f && transform.position.z > -383f))
        {
            return true;
        }

        return false;
    }

    private bool HasObstacleInContact()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, obstacleCheckRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Obstacles"))
            {
                 if (Physics.CheckSphere(transform.position, obstacleCheckRadius, 1 << collider.gameObject.layer))
                {
                    return true;
                }
            }
        }

        return false;
    }

}

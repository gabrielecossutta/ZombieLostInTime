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

    
    //[SerializeField] private float nightTimer = 10f;
    public Transform EnemyContainer;

    public bool oneTimeStop;
    public bool oneTimeStart;


    public bool isNight;
    private int howManyBoss;
    public int bossNumber;

    private Coroutine spawningCoroutine;
    private Coroutine bossSpawningCoroutine;



    private void Start()
    {
        oneTimeStop = false;
        oneTimeStart = false;
        howManyBoss = 0;
        bossNumber = 2;
        //StartCoroutine(StopSpawning(nightTimer));
    }
    private void OnEnable()
    {

        //StartCoroutine(Spawning());

        //StartCoroutine(BossSpawning());
        StartSpawning();

    }
    private void OnDisable()
    {
        StopSpawning();
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
    public void Update()
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
            if (canSpawn)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
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
            if (bossCanSpawn)
            {
                yield return waitBoss;
                int rand = Random.Range(0, bossPrefab.Count);
                Instantiate(bossPrefab[rand], transform.position, Quaternion.identity, EnemyContainer);
                bossPrefab.RemoveAt(rand);
                Debug.Log(bossPrefab.Count);
                howManyBoss++;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }


            //if (howManyBoss == bossNumber || TimerController.Instance.changingEra)
            //{
            //    bossCanSpawn = false;

            //}

        }

    }



}

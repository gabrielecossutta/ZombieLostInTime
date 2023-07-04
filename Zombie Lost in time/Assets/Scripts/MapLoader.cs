using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapLoader : Singleton<MapLoader>
{

    public GameObject portal;
    public bool isChanging = false;
    public GameObject Player;
    public List<Spawner> spawnerList;
    public Vector3 startPlayerPos;
    public bool destroyEnemy;
    public int Era;

    // Start is called before the first frame update
    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        startPlayerPos = Player.transform.position;
        destroyEnemy = false;
    }

    private void Update()
    {
        if (!isChanging)
        {
            ChangingEra();

        }

        if (!TimerController.Instance.changingEra && !spawnerList[0].canSpawn)
        {

            ResetPlayerPos();
            EraSelector(Era);
            RestartSpawn();
            Nottepertutti.Instance.ClearAll();
            isChanging = false;
        }


    }

    public void ChangingEra()
    {
        if (TimerController.Instance.changingEra)
        {
            isChanging = true;
            Era++;
            Debug.Log(Era);
            for (int i = 0; i < spawnerList.Count; i++)
            {
                spawnerList[i].GetComponent<Spawner>().SetCanSpawn(false);
            }
            spawnerList[0].GetComponent<Spawner>().SetBossCanSpawn(false);

            Vector3 offset = new Vector3(4, 0.05f, 4);
            portal.transform.position = Player.transform.position + offset;
            portal.SetActive(true);
            //Debug.Log("Changin era");
        }
    }

    public void RestartSpawn()
    {
        for (int i = 0; i < spawnerList.Count; i++)
        {
            spawnerList[i].GetComponent<Spawner>().SetCanSpawn(true);
            
        }
        spawnerList[0].GetComponent<Spawner>().SetBossCanSpawn(true);

    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync("Map_02", LoadSceneMode.Additive).completed += OnSceneLoadComplete;
        
    }

    private void OnSceneLoadComplete(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_01");

    }

    public void ChangeScene2()
    {
        SceneManager.LoadSceneAsync("Map_03", LoadSceneMode.Additive).completed += OnSceneLoadComplete2;
    }

    private void OnSceneLoadComplete2(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_02");
    }

    public void ChangeScene3()
    {
        SceneManager.LoadSceneAsync("Map_04", LoadSceneMode.Additive).completed += OnSceneLoadComplete3;
    }

    private void OnSceneLoadComplete3(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_03");
    }

    public void ResetPlayerPos()
    {
        Player.transform.position = startPlayerPos;
        destroyEnemy = true;
    }

    public void EraSelector(int Era)
    {
        switch (Era)
        {

            case 1:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 2;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 4;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(4);
                }
                
                Debug.Log("Era 2");
                break;
            case 2:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 4;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 6;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(3);
                }
                Debug.Log("Era 3");
                break;
            case 3:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 6;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 8;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(2);
                }
                Debug.Log("Era 3");
                break;
        }
    }
}

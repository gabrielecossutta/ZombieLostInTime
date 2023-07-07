using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapLoader : Singleton<MapLoader>
{
    public GameObject portal;
    public GameObject Player;
    public List<Spawner> spawnerList;
    public Vector3 startPlayerPos;
    public bool isChanging = false;
    public bool destroyEnemy = false;
    public int Era;

    // Start is called before the first frame update
    private void Start()
    {
        startPlayerPos = Player.transform.position;
    }

    private void Update()
    {
        if (!isChanging )
        {
            ChangingEra();
        }
        
        if (!TimerController.Instance.changingEra && !spawnerList[0].canSpawn && (Era != 4))
        {
            ResetPlayerPos(startPlayerPos);
            EraSelector(Era);
            RestartSpawn();
            Nottepertutti.Instance.ClearAll();
            isChanging = false;
        }
        if(TimerController.instance.latestEra)
        {
            ResetPlayerPos(startPlayerPos);
            EraSelector(Era);
            RestartSpawn();
            Nottepertutti.Instance.ClearAll();
            TimerController.instance.latestEra = false;
        }
    }

    public void ChangingEra()
    {
        if (TimerController.Instance.changingEra )
        {
            isChanging = true;
            Era++;
            for (int i = 0; i < spawnerList.Count; i++)
            {
                spawnerList[i].GetComponent<Spawner>().SetCanSpawn(false);
            }
                spawnerList[0].GetComponent<Spawner>().SetBossCanSpawn(false);

                
            
            
            


            Vector3 offset = new Vector3(4, 0.05f, 4);
            portal.transform.position = Player.transform.position + offset;
            portal.SetActive(true);
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
        FindObjectOfType<AudioManager>().Play("VikingStage");

    }

    private void OnSceneLoadComplete(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_01");
        FindObjectOfType<AudioManager>().Stop("MedievalStage");
    }

    public void ChangeScene2()
    {
        SceneManager.LoadSceneAsync("Map_03", LoadSceneMode.Additive).completed += OnSceneLoadComplete2;
        FindObjectOfType<AudioManager>().Play("WesternStage");
    }

    private void OnSceneLoadComplete2(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_02");
        FindObjectOfType<AudioManager>().Stop("VikingStage");
    }

    public void ChangeScene3()
    {
        SceneManager.LoadSceneAsync("Map_04", LoadSceneMode.Additive).completed += OnSceneLoadComplete3;
        FindObjectOfType<AudioManager>().Play("SamuraiStage");
    }

    private void OnSceneLoadComplete3(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_03");
        FindObjectOfType<AudioManager>().Stop("WesternStage");
    }

    public void ChangeScene4()
    {
        SceneManager.LoadSceneAsync("Map_05", LoadSceneMode.Additive).completed += OnSceneLoadComplete4;
        FindObjectOfType<AudioManager>().Play("ModernStage");
    }

    private void OnSceneLoadComplete4(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_04");
        FindObjectOfType<AudioManager>().Stop("SamuraiStage");
    }

    public void ResetPlayerPos(Vector3 startPlayerPos)
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
                break;
            case 2:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 4;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 6;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(3);
                }
                break;
            case 3:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 6;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 8;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(2);
                }
                break;
            case 4:
                for (int i = 0; i < spawnerList.Count; i++)
                {
                    spawnerList[i].GetComponent<Spawner>().EraStart = 0;
                    spawnerList[i].GetComponent<Spawner>().EraEnd = 8;
                    spawnerList[i].GetComponent<Spawner>().SetSpawnRate(1);
                }
                break;
        }
    }
}

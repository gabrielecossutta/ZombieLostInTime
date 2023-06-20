using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapLoader : Singleton<MapLoader>
{
    
    public GameObject portal;
    public bool isChanging = false;
    private GameObject Player;
    public List<Spawner> spawnerList;
    private Vector3 startPlayerPos;

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startPlayerPos = Player.transform.position;
    }
    private void Update()
    {
        if (!isChanging)
        {
            ChangingEra();

        }

        if (!TimerController.Instance.changingEra && !spawnerList[0].canSpawn)
        {
            RestartSpawn();
            

        }


    }


    public void ChangingEra()
    {
        if (TimerController.Instance.changingEra)
        {
            isChanging = true;

            for (int i = 0; i < spawnerList.Count; i++)
            {
                spawnerList[i].GetComponent<Spawner>().SetCanSpawn(false);
            }
                spawnerList[0].GetComponent<Spawner>().SetBossCanSpawn(false);
            


            Vector3 offset = new Vector3(4, 1, 4);
            portal.transform.position = Player.transform.position + offset;
            portal.SetActive(true);
            Debug.Log("Changin era");
        }
    }

    public void RestartSpawn()
    {
        for (int i = 0; i < spawnerList.Count; i++)
        {
            spawnerList[i].GetComponent<Spawner>().SetCanSpawn(true);
            Debug.Log(spawnerList[i] + "Settato  a  true");
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

    //public void ResetPlayerPos()
    //{
    //    Player.transform.position = startPlayerPos;
    //}

}

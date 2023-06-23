using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonHandlerForExit : Singleton<ButtonHandlerForExit>
{
    public GameObject canvas;
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] GameObject newFirstSelectedGameObject;

    private void Update()
    {
        if (Status.Instance.currentHealth < 0)
        {
            canvas.SetActive(true);
        }
        _eventSystem.currentSelectedGameObject = newFirstSelectedGameObject;

    }

    public void Restart()
    {
        SceneManager.LoadScene("DefaultMap");
        SceneManager.LoadSceneAsync("Map_01", LoadSceneMode.Additive).completed += UnloadScene;
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif       
        Application.Quit();                                    /*< --Funzione per chiudere l'applicazione */
    }

    public void UnloadScene(AsyncOperation asyncOp)
    {
        SceneManager.UnloadSceneAsync("Map_02");
    }
}

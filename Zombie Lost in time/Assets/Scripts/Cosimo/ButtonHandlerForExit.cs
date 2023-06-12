using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlerForExit : Singleton<ButtonHandlerForExit>
{
    public GameObject canvas;
    private void Update()
    {
        if (Status.Instance.currentHealth < 0)
        {
            canvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif       
        Application.Quit();                                    /*< --Funzione per chiudere l'applicazione */
    }
}

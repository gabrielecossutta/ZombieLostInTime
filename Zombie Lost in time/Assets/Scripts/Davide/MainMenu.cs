using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DefaultMap");
        FindObjectOfType<AudioManager>().Play("MedievalStage");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif       
        Application.Quit();                                    /*< --Funzione per chiudere l'applicazione */
    }
}

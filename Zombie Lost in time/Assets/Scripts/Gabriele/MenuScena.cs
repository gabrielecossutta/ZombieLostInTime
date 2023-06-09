using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuScena: MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void Giorno() // metodo per quando si clicca il tasto e viene caricato il giorno
    {
        SceneManager.LoadScene("Giorno");
    }
    public void Notte() // metodo per quando si clicca il tasto e viene caricata la notte
    {
        SceneManager.LoadScene("Notte");
    }
    public void quitScene()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonHandlerForExit : MonoBehaviour
{
    public GameObject deathMenu;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _restartButtonFirst;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(_restartButtonFirst);
    }
    private void OnDisable()
    {
        Time.timeScale = 1.0f;

    }

    private void Update()
    {
        if (Status.Instance.currentHealth <= 0)
        {
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        deathMenu.SetActive(false);
        SceneManager.LoadScene("DefaultMap");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif       
        Application.Quit();                                    /*< --Funzione per chiudere l'applicazione */
    }
}

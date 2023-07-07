using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _keyboardCanvasGO;
    [SerializeField] private GameObject _gamepadCanvasGO;
    [SerializeField] private GameObject _gameCanvasGO;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _keyboardFirst;
    [SerializeField] private GameObject _gamepadFirst;
    [SerializeField] private GameObject _gameFirst;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UserInput.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                FindObjectOfType<AudioManager>().Pause("FlameThrower");
                FindObjectOfType<AudioManager>().Pause("DamageZone");
                Pause();
            }
            else
            {
                FindObjectOfType<AudioManager>().UnPause("FlameThrower");
                FindObjectOfType<AudioManager>().UnPause("DamageZone");
                UnPause();
            }
        }
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenMainMenu();
    }

    private void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif       
        Application.Quit();                                    /*< --Funzione per chiudere l'applicazione */
    }

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnResumePress()
    {
        UnPause();
    }

    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }

    public void OnControlsBackPress()
    {
        _keyboardCanvasGO.SetActive(false);
        _gamepadCanvasGO.SetActive(false);
        _gameCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }


    public void OnKeyboardControlsPress()
    {
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardCanvasGO.SetActive(true);
        _gameCanvasGO.SetActive(false);
        _gamepadCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_keyboardFirst);
    }

    public void OnGamepadControlsPress()
    {
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardCanvasGO.SetActive(false);
        _gameCanvasGO.SetActive(false);
        _gamepadCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_gamepadFirst);
    }
    public void OnGameControlsPress()
    {
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardCanvasGO.SetActive(false);
        _gameCanvasGO.SetActive(true);
        _gamepadCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_gameFirst);
    }
}

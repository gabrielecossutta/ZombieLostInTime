using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _creditsCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _keyboardCanvasGO;
    [SerializeField] private GameObject _gamepadCanvasGO;
    [SerializeField] private GameObject _gameCanvasGO;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _creditsFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _keyboardFirst;
    [SerializeField] private GameObject _gamepadFirst;
    [SerializeField] private GameObject _gameFirst;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle()
    {
        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }

    public void OnControlsBackPress()
    {
        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }


    public void OnKeyboardControlsPress()
    {
        EventSystem.current.SetSelectedGameObject(_keyboardFirst);
    }

    public void OnGamepadControlsPress()
    {
        EventSystem.current.SetSelectedGameObject(_gamepadFirst);
    }

    public void OnGameControlsPress()
    {
        EventSystem.current.SetSelectedGameObject(_gameFirst);
    }
    public void OnCreditsPress()
    {
        EventSystem.current.SetSelectedGameObject(_creditsFirst);
    }
}

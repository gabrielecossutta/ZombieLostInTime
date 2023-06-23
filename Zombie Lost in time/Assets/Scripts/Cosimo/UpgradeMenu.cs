using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeMenu : Singleton<UpgradeMenu>
{
    public GameObject UpgradeMenuPanel;
    public GameObject UpgradePlayerStatsMenu;
    public GameObject UpgradeWeaponsStatsMenu;
    public TMP_Text pointOwnedText;
    public EventSystem _eventSystem;
    public GameObject newFirstSelectedGameObject;
    private GameObject _firstSelectedGameObject;

    [HideInInspector]public int pointToLvlUp = 1;
    public int pointsOwned;

    private void Start()
    {
        _firstSelectedGameObject = EventSystem.current.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pointOwnedText.text = "Punti: " + pointsOwned.ToString();
    }

    public void OpenUpgradeMenu(int pointsOwned)
    {
        Pause();
        this.pointsOwned += pointsOwned;
    }

    public void Resume()
    {
        UpgradeMenuPanel.SetActive(false);
        UpgradePlayerStatsMenu.SetActive(false);
        UpgradeWeaponsStatsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        UpgradeMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SetActivePlayerUpgradeMenu()
    {
        UpgradeWeaponsStatsMenu.SetActive(false);
        UpgradePlayerStatsMenu.SetActive(true);
    }

    public void SetActiveWeaponsUpgradeMenu()
    {
        UpgradePlayerStatsMenu.SetActive(false);
        UpgradeWeaponsStatsMenu.SetActive(true);
    }

    public void SetFirstSelectedGameObj()
    {
        _eventSystem.currentSelectedGameObject = _firstSelectedGameObject;
    }
}

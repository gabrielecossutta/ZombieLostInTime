using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject UpgradeMenuPanel;
    public GameObject UpgradePlayerStatsMenu;
    public GameObject UpgradeWeaponsStatsMenu;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused) 
            {
                UpgradePlayerStatsMenu.SetActive(false);
                UpgradeWeaponsStatsMenu.SetActive(false);
                Resume();
            }
            else
                Pause();
        }
    }
    public void Resume()
    {
        UpgradeMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        UpgradeMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
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
}

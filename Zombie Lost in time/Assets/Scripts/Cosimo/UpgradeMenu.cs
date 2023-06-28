using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeMenu : Singleton<UpgradeMenu>
{
    public GameObject UpgradeMenuPanel;
    public GameObject UpgradePlayerStatsMenu;
    public GameObject UpgradeWeaponsStatsMenu;
    public TMP_Text pointOwnedText;

    [HideInInspector] public int pointToLvlUp = 1;
    public int pointsOwned;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _playerMenuFirst;
    [SerializeField] private GameObject _weaponMenuFirst;

    // Update is called once per frame
    void Update()
    {
        pointOwnedText.text = "Punti: " + pointsOwned.ToString();
    }

    public void OpenUpgradeMenu(int pointsOwned)
    {
        Pause();
        UpgradeMenuPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_playerMenuFirst);
        this.pointsOwned += pointsOwned;
    }

    public void Resume()
    {
        EventSystem.current.SetSelectedGameObject(null);
        UpgradeMenuPanel.SetActive(false);
        UpgradePlayerStatsMenu.SetActive(false);
        UpgradeWeaponsStatsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
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
}

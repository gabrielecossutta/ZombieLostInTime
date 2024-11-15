using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject panel;
    public void ClosePanel()
    {
        panel.SetActive(false);
        UpgradeMenu.Instance.Resume();
    }
}

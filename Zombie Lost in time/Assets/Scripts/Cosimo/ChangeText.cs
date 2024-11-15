using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private int lvl = 0;

    private void Start()
    {
        textMeshPro.text = lvl.ToString();
    }

    public void AddValue()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0 && UpgradePlayerStats.Instance.cont < UpgradePlayerStats.Instance.maxSpeedUpgrade)
        {
            lvl++;
            textMeshPro.text = lvl.ToString();
        }
    }
}




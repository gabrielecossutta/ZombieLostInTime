using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    private int lvl = 1;

    private void Start()
    {
        textMeshPro.text = lvl.ToString();
    }

    public void AddValue()
    {
        if (UpgradeMenu.Instance.pointsOwned > 0)
        {
            lvl++;
            textMeshPro.text = lvl.ToString();
        }
        //if (UpgradeWeaponsStats.Instance.isMaxed)
        //{
        //    textMeshPro.text = "Level Max";
        //}
        //if (UpgradePlayerStats.Instance.isMaxed)
        //{
        //    textMeshPro.text = "Level Max";
        //}

    }
}




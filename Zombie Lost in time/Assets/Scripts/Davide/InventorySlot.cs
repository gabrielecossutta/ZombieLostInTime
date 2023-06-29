using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI level;
    public void Set(InventoryItem powerUp)
    {
        icon.sprite = powerUp.data.Icon;
        level.text = powerUp.stackSize.ToString();
    }
}

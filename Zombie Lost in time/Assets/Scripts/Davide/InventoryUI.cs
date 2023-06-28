using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotprefab;
    private void Start()
    {
        ToolManager.Instance.OnToolChange += OnUpdateInventory;
    }
    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        ListPowerUps();
    }

    public void ListPowerUps()
    {   foreach(InventoryItem item in ToolManager.Instance.powerUpData)
        {
            AddPowerUpSlot(item);
        }
    }

    public void AddPowerUpSlot(InventoryItem powerUps)
    {
        GameObject obj = Instantiate(slotprefab);
        obj.transform.SetParent(transform, false);

        InventorySlot slot = obj.GetComponent<InventorySlot>();
        slot.Set(powerUps);
    }
}

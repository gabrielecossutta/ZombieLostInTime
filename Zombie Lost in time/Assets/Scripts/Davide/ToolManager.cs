using System;
using System.Collections.Generic;


public class ToolManager : Singleton<ToolManager>
{
    public event Action OnToolChange;
    private Dictionary<PowerUpData, InventoryItem> powerUps;
    public List<InventoryItem> powerUpData;

    private void Awake()
    {
        powerUpData = new List<InventoryItem>();
        powerUps = new Dictionary<PowerUpData, InventoryItem>();
    }
    private void Update()
    {
        OnToolChange();
    }
    public void AddInvP(PowerUpData powerUp)
    {
        if (powerUps.TryGetValue(powerUp, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newPowerUp = new InventoryItem(powerUp);
            powerUpData.Add(newPowerUp);
            powerUps.Add(powerUp, newPowerUp);
        }
    }
    public void OnDestroy()
    {
        powerUpData.Clear();
        powerUps.Clear();
    }
}

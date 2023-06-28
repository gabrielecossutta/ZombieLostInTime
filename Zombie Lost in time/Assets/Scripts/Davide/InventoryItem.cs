using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public PowerUpData data;
    public int stackSize;

    public InventoryItem(PowerUpData source)
    {
        data = source;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveToStack()
    {
        stackSize--;
    }
}

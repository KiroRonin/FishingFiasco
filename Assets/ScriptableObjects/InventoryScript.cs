using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryScript : ScriptableObject
{
   public List<FishScriptableObject> Container = new List<FishScriptableObject>();
}

[System.Serializable]
public class InventorySlot 
{
    public FishScriptableObject fish;
    public int amount;
    
    public InventorySlot(FishScriptableObject _fish, int _amount)
    {
        fish = _fish;
        amount = _amount;
    }

    public void AddAmount(int value)
    {

    }
}
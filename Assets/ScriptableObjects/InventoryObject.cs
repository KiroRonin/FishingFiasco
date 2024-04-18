using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

[CreateAssetMenu (fileName = "New Inventory", menuName = "Inventory System")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();



    public void AddFish(FishObject _fish, int _amount){
        
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].fish == _fish){
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(_fish, _amount));
        
    }

}

[System.Serializable]
public class InventorySlot{
    public FishObject fish;
    public int amount;
    //public int currentNPCAmount;
    //public int NPCFull;

    public InventorySlot(FishObject _fish, int _amount){
        fish = _fish;
        amount = _amount;
    }

    public void AddAmount(int value){
        amount += value;
    }
}

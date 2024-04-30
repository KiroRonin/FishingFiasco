using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

[CreateAssetMenu (fileName = "New Trade Inventory", menuName = "Trade Inventory System")]
public class TradeInventoryObject : ScriptableObject
{
    public List<TradeInventorySlot> tradeContainer = new List<TradeInventorySlot>();

    public void AddFish(FishObject _fish, int _currentAmount, int _fullAmount){
        
        for (int i = 0; i < tradeContainer.Count; i++)
        {
            if(tradeContainer[i].fish == _fish){
                tradeContainer[i].AddAmount(_currentAmount);
                return;
            }
        }
        tradeContainer.Add(new TradeInventorySlot(_fish, _currentAmount, _fullAmount));
        
    }

}

[System.Serializable]
public class TradeInventorySlot{
    public FishObject fish;
    public int currentAmount;
    public int fullAmount;
    //public int currentNPCAmount;
    //public int NPCFull;

    public TradeInventorySlot(FishObject _fish, int _currentAmount, int _fullAmount){
        fish = _fish;
        currentAmount = _currentAmount;
        fullAmount = _fullAmount;
    }

    public void AddAmount(int value){
        currentAmount += value;
    }
}

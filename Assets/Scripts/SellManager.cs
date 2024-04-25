using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public InventoryObject npcInventory;

    public FishObject currentFish;
    
    //public int currentFishID;

    // Update is called once per frame
    void Update()
    {
        //npcInventory = DiaManager.instance.currentNPC.npcInventory; 
        Debug.Log("current fish id: "+ currentFish.Id);
    }

    void tradeFish(){
        
    }
}

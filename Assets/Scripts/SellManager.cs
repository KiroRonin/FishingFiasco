using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public InventoryObject npcInventory;

    public FishObject currentFish;
    public int currentFishID;

    public GameObject currentButton;

    // Update is called once per frame
    void Update()
    {
        //npcInventory = DiaManager.instance.currentNPC.npcInventory; 
        Debug.Log("current fish id: "+ currentFish.Id);
        print(currentFishID);
    }

    void tradeFish(){
        
    }

    public void clickCurrentFish()
    {
        //currentFishID = GetComponent<fishDataGather>().sendFishId();
        currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        print(currentButton);
        currentFish = currentButton.GetComponent<fishDataGather>().sendFishId();
        print(currentFish);
        currentFishID = currentFish.Id;
        print(currentFishID);
    }
}

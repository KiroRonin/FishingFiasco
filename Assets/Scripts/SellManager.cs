using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public InventoryObject npcInventory;

    public FishObject currentFish;
    public int currentFishID;

    public GameObject currentButton;

    public itemslot itemslot;

    public int fishID;

    // Update is called once per frame
    void Update()
    {
        clickCurrentFish();
        //npcInventory = DiaManager.instance.currentNPC.npcInventory; 
        Debug.Log("current fish id: "+ fishID);
        print(currentFishID);
    }

    void tradeFish(){
        

    }

    public void clickCurrentFish()
    {
        //currentFishID = GetComponent<fishDataGather>().sendFishId();
        currentButton = EventSystem.current.currentSelectedGameObject;
        print(currentButton);

        currentFish = currentButton.GetComponent<fishDataGather>().sendFishId();
        print(currentFish);

        currentFishID = currentFish.Id;
        print(currentFishID);
        fishID = currentFishID;
    }
}

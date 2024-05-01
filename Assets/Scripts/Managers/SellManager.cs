using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellManager : MonoBehaviour
{
    public InventoryObject playerInventory;
    public TradeInventoryObject npcInventory;

    public GameObject inventoryBackground;

    public FishObject currentFish;
    public int currentFishID;
    public GameObject currentButton;

    public DisplayInventory displayInventory;

    public itemslot itemslot;


    void tradeFish(){
        
    }

    public void clickCurrentFish()
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        currentFish = currentButton.GetComponent<fishDataGather>().sendFishId();
        currentFishID = currentFish.Id;
        print("clickfish id: "+currentFishID);
    }


    public void trashFish()
    {
        print("trash clicked");

        if (currentButton.GetComponent<fishDataGather>().fish.Id == currentFishID)
        {
            print("clicked");
            Destroy(currentButton);

            for (int i = 0; i < playerInventory.Container.Count; i++)
            {
                if (playerInventory.Container[i].fish.Id == currentFishID)
                {
                    print(currentFish);
                    playerInventory.Container[i].amount = 0;
                    checkEmpty(i);
                    displayInventory.UpdateDisplay();
                }
            }
            
        }
        
    }

     void checkEmpty(int i)
    {
        print(playerInventory.Container[i].fish);
        print(playerInventory.Container[i].amount);

        if (playerInventory.Container[i].amount == 0)
        {
            playerInventory.Container.RemoveAt(i);
            var slot = inventoryBackground.transform.GetChild(i).gameObject;
            var display = slot.transform.GetChild(0).gameObject;
            print("destroying slot "+i);
            Destroy(display);
        }
    }
}
